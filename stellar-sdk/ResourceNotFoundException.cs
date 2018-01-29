using System;

namespace StellarSdk
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base()
        {
        }

        public ResourceNotFoundException(string message)
            : base(message)
        {

        }
    }
}
