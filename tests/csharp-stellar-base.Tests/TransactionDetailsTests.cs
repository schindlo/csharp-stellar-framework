﻿using System;
using Xunit;
using StellarSdk;
using StellarSdk.Exceptions;
using StellarBase;

namespace csharp_stellar_base.Tests
{
    public class TransactionDetailsTests
    {
        static string horizon_url = "https://horizon-testnet.stellar.org/";
        static string network_passphrase = "Test SDF Network ; September 2015";

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

        [Fact]
        public async void TestSubmitInvalidTransaction()
        {
            // submit an invalid tx
            TransactionCallBuilder builder = new TransactionCallBuilder(horizon_url);
            builder.submitTransaction("invalid tx test");
            try
            {
                await builder.Call();
                Assert.Equal("Expected BadRequestException", null);
            }
            catch(BadRequestException e)
            {
                Assert.Equal(400, e.ErrorDetails.Status);
                Assert.NotNull(e.ErrorDetails.Title);
            }
        }

        [Fact]
        public async void TestSubmitTransactionMissingAmount()
        {
            StellarBase.Network.CurrentNetwork = network_passphrase;

            AccountCallBuilder accountBuilder = new AccountCallBuilder(horizon_url);
            accountBuilder.accountId("GBLQWS2KU3GW67KXQKAWWAML33465ZDVOWCEVV5TU2PHXMZUA3PFQM5C");
            var t = await accountBuilder.Call();


            var sourceKeyPair = KeyPair.FromSeed("SDMJOANF6CDRHWVG3N6I34VHFEWD2KK5I5SPGFU5FDB6SY5FJNXTWN24");
            Account sourceAccount = new Account(sourceKeyPair, long.Parse(t.Sequence));

            var destinationKeyPair = KeyPair.FromAddress("GDGUDD3WNMAZD6GQXXJXZMJKMCADEZJDA74TAQJSEEPTLNL4PYHZVM4T");

            // make payment with amount > source balance
            double amount = double.Parse(t.Balances[0].Balance);
            var operation =
                new PaymentOperation.Builder(destinationKeyPair, new Asset(), (long)(amount * StellarBase.One.Value) + 10)
                .SetSourceAccount(sourceKeyPair)
                .Build();

            sourceAccount.IncrementSequenceNumber();
            var transaction = new StellarBase.Transaction.Builder(sourceAccount)
                .AddOperation(operation)
                .Build();
            
            transaction.Sign(sourceAccount.KeyPair);
            var txSigned = transaction.ToEnvelopeXdrBase64();

            TransactionCallBuilder txBuilder = new TransactionCallBuilder(horizon_url);
            txBuilder.submitTransaction(txSigned);
            try
            {
                var tx = await txBuilder.Call();
                Assert.Equal("Expected BadRequestException", null);
            }
            catch (BadRequestException e)
            {
                Assert.Equal(400, e.ErrorDetails.Status);
                Assert.Equal("tx_failed", e.ErrorDetails.Extras.ResultCodes.Transaction);
                Assert.Equal("op_underfunded", e.ErrorDetails.Extras.ResultCodes.Operations[0]);
            }
        }
    }
}
