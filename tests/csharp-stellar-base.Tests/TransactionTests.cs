﻿using Xunit;
using Stellar;
using Stellar.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_stellar_base.Tests
{
    public class TransactionTests
    {
        public TransactionTests()
        {
            Stellar.Network.CurrentNetwork = "";
        }

        public Stellar.Transaction SampleTransaction(string destAccountId)
        {
            Stellar.Network.CurrentNetwork = "";

            var master = KeyPair.Master();
            var dest = string.IsNullOrEmpty(destAccountId) ? KeyPair.Random() : KeyPair.FromAccountId(destAccountId);

            var sourceAccount = new Account(master, 1);

            CreateAccountOperation operation =
                new CreateAccountOperation.Builder(dest, 1000)
                //.SetSourceAccount(master)
                .Build();

            Stellar.Transaction transaction =
                new Stellar.Transaction.Builder(sourceAccount)
                .AddOperation(operation)
                .Build();

            return transaction;
        }

        [Fact]
        public void SignatureBaseTest()
        {
            var transaction = SampleTransaction("GDICFS3KJ3ZTW4COVPUX7OCOAZKLLNFAM5FIYSN5FKKM7M7QNXLBPCCH");
            var txXdr = transaction.ToXDR();

            var writer = new Stellar.Generated.ByteWriter();
            Stellar.Generated.Transaction.Encode(writer, txXdr);
            string sig64 = Convert.ToBase64String(writer.ToArray());

            string sigSample64 = "AAAAAL6Qe0ushP7lzogR2y3vyb8LKiorvD1U2KIlfs1wRBliAAAAZAAAAAAAAAABAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAA0CLLak7zO3BOq+l/uE4GVLW0oGdKjEm9KpTPs/Bt1hcAAAAAAAAD6AAAAAA=";
            byte[] sigSample = Convert.FromBase64String(sigSample64);

            var reader = new Stellar.Generated.ByteReader(sigSample);
            var sampleTx = Stellar.Generated.Transaction.Decode(reader);

            Assert.Equal(writer.ToArray(), sigSample);

            Assert.Equal(sigSample64, sig64);
        }

        [Fact]
        public void HashTest()
        {
            var transaction = SampleTransaction("GDICFS3KJ3ZTW4COVPUX7OCOAZKLLNFAM5FIYSN5FKKM7M7QNXLBPCCH");

            byte[] hash = transaction.Hash();
            string hash64 = Convert.ToBase64String(hash);

            string hashSample64 = "bMPzusbyC+LYcRcxTilrKuSSKTwMVE+vbFdN745w1to=";

            Assert.Equal(hashSample64, hash64);
        }
    }
}