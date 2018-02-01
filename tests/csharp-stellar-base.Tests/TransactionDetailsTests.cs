using System;
using Xunit;
using StellarSdk;
using StellarSdk.Exceptions;

namespace csharp_stellar_base.Tests
{
    public class TransactionDetailsTests
    {
        static string horizon_url = "https://horizon-testnet.stellar.org/";

        [Fact]
        public async void TestTransactionDetails()
        {
            TransactionCallBuilder builder = new TransactionCallBuilder(horizon_url);
            // TODO: need valid signed tx
            builder.submitTransaction("AAAAAOo1QK/3upA74NLkdq4Io3DQAQZPi4TVhuDnvCYQTKIVAAAACgAAH8AAAAABAAAAAAAAAAAAAAABAAAAAQAAAADqNUCv97qQO+DS5HauCKNw0AEGT4uE1Ybg57wmEEyiFQAAAAEAAAAAZc2EuuEa2W1PAKmaqVquHuzUMHaEiRs//+ODOfgWiz8AAAAAAAAAAAAAA+gAAAAAAAAAARBMohUAAABAPnnZL8uPlS+c/AM02r4EbxnZuXmP6pQHvSGmxdOb0SzyfDB2jUKjDtL+NC7zcMIyw4NjTa9Ebp4lvONEf4yDBA==");
            var tx = await builder.Call();
            Console.WriteLine(tx.Hash);

            builder.transaction(tx.Hash);
            var txDetail = await builder.Call();

            Console.WriteLine(txDetail.Id);
        }
    }
}
