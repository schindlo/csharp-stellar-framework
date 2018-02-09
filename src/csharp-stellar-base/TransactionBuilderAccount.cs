﻿namespace StellarBase
{
    public interface ITransactionBuilderAccount
    {
        KeyPair KeyPair { get; }

        long SequenceNumber { get; }

        void IncrementSequenceNumber();
    }
}
