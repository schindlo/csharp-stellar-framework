﻿using System;
using System.Threading.Tasks;
using StellarSdk.Model;

namespace StellarSdk
{
    public class AccountCallBuilder : CallBuilder
    {
        public AccountCallBuilder(String serverUrl) : base(serverUrl)
        {
            isIdempotent = true;
            addSegment("accounts");
        }

        public AccountCallBuilder accountId(String id)
        {
            addFilter(id);

            return this;
        }

        public async Task<AccountDetails> Call()
        {
            var txt = await base.DoCall();
            return AccountDetails.FromJson(txt);
        }
    }
}
