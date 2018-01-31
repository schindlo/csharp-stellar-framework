using System;
using Newtonsoft.Json;

namespace StellarSdk.Model
{
    public class TransactionDetails
    {
        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("paging_token")]
        public string PagingToken { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("ledger")]
        public long Ledger { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("account_sequence")]
        public long AccountSequence { get; set; }

        [JsonProperty("max_fee")]
        public long MaxFee { get; set; }

        [JsonProperty("fee_paid")]
        public long FeePaid { get; set; }

        [JsonProperty("operation_count")]
        public long OperationCount { get; set; }

        [JsonProperty("result_code")]
        public long ResultCode { get; set; }

        [JsonProperty("result_code_s")]
        public string ResultCodeS { get; set; }

        [JsonProperty("envelope_xdr")]
        public string EnvelopeXdr { get; set; }

        [JsonProperty("result_xdr")]
        public string ResultXdr { get; set; }

        [JsonProperty("result_meta_xdr")]
        public string ResultMetaXdr { get; set; }

        public static TransactionDetails FromJson(string json) => JsonConvert.DeserializeObject<TransactionDetails>(json, Converter.Settings);

        public static string ToJson(TransactionDetails self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
