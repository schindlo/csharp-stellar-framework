using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StellarSdk.Exceptions;

namespace StellarSdk
{
    public class CallBuilder
    {
        private String url;
        private List<string> filters;
        private List<KeyValuePair<string, string>> bodyParams;

        // services marked as idempotent will be retried in case of transient failures
        protected Boolean isIdempotent;

        public CallBuilder(String serverUrl)
        {
            url = serverUrl;
            filters = new List<string>();
            bodyParams = new List<KeyValuePair<string, string>>();
            isIdempotent = false;
        }

        public void addSegment(string segment)
        {
            url = url + "/" + segment;
        }

        public void addFilter(string value)
        {
            filters.Add(value);
        }

        public void addBody(string param, string value)
        {
            bodyParams.Add(new KeyValuePair<string, string>(param, value));
        }

        private void checkFilter()
        {
            if(filters.Count >= 2)
            {
                throw new ArgumentException("Invalid filters");
            }
            if(filters.Count == 1)
            {
                url = url + "/" + filters[0];
            }
        }

        // TODO: log errors
        // TODO: parse 400 error, e.g submit an invalid transaction
        public async Task<String> DoCall()
        {
            this.checkFilter();
            int retries = isIdempotent ? 1 : 0;
            for (int attempt = 0; attempt <= retries; attempt++)
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = null;
                    try
                    {
                        if (bodyParams.Count > 0)
                        {
                            // POST
                            var formUrlEncodedContent = new FormUrlEncodedContent(bodyParams);
                            response = await client.PostAsync(url, formUrlEncodedContent);
                        }
                        else
                        {
                            // GET
                            response = await client.GetAsync(url);
                        }
                    }
                    catch (Exception e)
                    {
                        if (attempt < retries)
                        {
                            // retry
                            continue;
                        }
                        else
                        {
                            throw e;
                        }
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else if (((int)response.StatusCode) == 404)
                    {
                        throw new ResourceNotFoundException();
                    }
                    else if (((int)response.StatusCode) == 500 && attempt < retries)
                    {
                        // retry
                        continue;
                    }
                    else
                    {
                        throw new TechnicalException("HTTP Error from REST API: " + response.StatusCode);
                    }
                }
            }

            // unreachable
            return null;
        }
    }
}
