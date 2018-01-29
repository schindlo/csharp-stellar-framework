﻿using System;
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
        public async void TestBalance()
        {
            AccountCallBuilder builder = new AccountCallBuilder(horizon_url);
            builder.accountId("GBLQWS2KU3GW67KXQKAWWAML33465ZDVOWCEVV5TU2PHXMZUA3PFQM5C");
            var t = await builder.Call();

            Console.WriteLine(t.Balances[0].Balance);
        }

        [Fact]
        public async void TestBalanceInvalidAddress()
        {
            AccountCallBuilder builder = new AccountCallBuilder(horizon_url);
            builder.accountId("not existing address");

            await Assert.ThrowsAsync<ResourceNotFoundException>(() => builder.Call());
        }
    }
}
