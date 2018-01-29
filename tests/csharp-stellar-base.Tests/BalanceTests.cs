using System;
using Xunit;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using StellarSdk;
using StellarSdk.Model;

namespace csharp_stellar_base.Tests
{
    public class BalanceTests
    {

        static string horizon_url = "https://horizon-testnet.stellar.org/";

        [Fact]
        public void TestBalance()
        {
            //var t = await GetBalance("GBLQWS2KU3GW67KXQKAWWAML33465ZDVOWCEVV5TU2PHXMZUA3PFQM5C");
            AccountCallBuilder builder = new AccountCallBuilder(horizon_url);
            builder.accountId("GBLQWS2KU3GW67KXQKAWWAML33465ZDVOWCEVV5TU2PHXMZUA3PFQM5C");
            var t = builder.Call();

            Console.WriteLine(t.Balances[0].Balance);
        }

        private async static Task<double> GetBalance(string address)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(horizon_url + "accounts/" + address);
                //string response = client.GetStringAsync(horizon_url + "accounts/" + address).Result;
                if(response.IsSuccessStatusCode)
                {
                    String txt = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(txt);
                    return (double)json["balances"][0]["balance"];
                }
                else
                {
                    // TODO
                    Console.WriteLine("Error: " + response.StatusCode);
                    return 0;
                }
            }
        }
    }
}
