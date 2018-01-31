using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StellarSdk
{
    public class CallBuilder
    {
        private String url;
        protected Dictionary<string, string> filters;

        // services marked as idempotent will be retried in case of transient failures
        protected Boolean isIdempotent;

        public CallBuilder(String serverUrl)
        {
            url = serverUrl;
            filters = new Dictionary<string, string>();
            isIdempotent = false;
        }

        private void checkFilter()
        {
            if(filters.Count >= 2)
            {
                throw new ArgumentException("Invalid filters");
            }
            if(filters.Count == 1)
            {
                var e = filters.Keys.GetEnumerator();
                e.MoveNext();
                var param = e.Current;
                url = url + "/" + param + "/" + filters[param];
            }
        }

        // TODO: log errors
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
                        response = await client.GetAsync(url);
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
