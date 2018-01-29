using System;
using StellarSdk.Model;

namespace StellarSdk
{
    public class AccountCallBuilder : CallBuilder
    {
        public AccountCallBuilder(String serverUrl) : base(serverUrl)
        {

        }

        public AccountCallBuilder accountId(String id)
        {
            filters.Add("accounts", id);

            return this;
        }

        public AccountDetails Call()
        {
            return AccountDetails.FromJson(base.DoCall().Result);
        }
    }
}
