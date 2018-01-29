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

        public CallBuilder(String serverUrl)
        {
            url = serverUrl;
            filters = new Dictionary<string, string>();
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

        public async Task<String> DoCall()
        {
            this.checkFilter();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else if(((int)response.StatusCode) == 404)
                {
                    throw new ResourceNotFoundException();
                }
                else
                {
                    throw new TechnicalException("Error from REST API: " + response.StatusCode);
                }
            }
        }
    }
}
