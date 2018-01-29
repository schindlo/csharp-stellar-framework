using System;

namespace StellarSdk
{
    public class TechnicalException : Exception
    {
        public TechnicalException() : base()
        {
        }

        public TechnicalException(string message)
            : base(message)
        {

        }
    }
}
