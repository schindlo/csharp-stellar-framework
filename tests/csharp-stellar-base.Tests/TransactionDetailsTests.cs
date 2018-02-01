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
            // submit a tx
            TransactionCallBuilder builder = new TransactionCallBuilder(horizon_url);
            builder.submitTransaction("AAAAAFcLS0qmzW99V4KBawGL3vnu5HV1hErXs6aee7M0Bt5YAAAAZABkLeoAAABOAAAAAAAAAAAAAAABAAAAAAAAAAEAAAAAzUGPdmsBkfjQvdN8sSpggDJlIwf5MEEyIR81tXx+D5oAAAAAAAAAAACYloAAAAAAAAAAATQG3lgAAABAG73QJD9U8f41h4a6FFsqtww6c9ww4s1lN/YgX9qzxlmEjTsTvwgmlqwanwPJA4TZyCMcmyTUFqwzi/rBdUJ7AQ==");
            var tx = await builder.Call();
            Assert.NotNull(tx.Hash);

            // read details of this tx
            builder = new TransactionCallBuilder(horizon_url);
            builder.transaction(tx.Hash);
            var txDetail = await builder.Call();
            Assert.Equal(tx.Hash, txDetail.Hash);
        }
    }
}
