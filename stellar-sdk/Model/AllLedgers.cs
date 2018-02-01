using Newtonsoft.Json;

namespace StellarSdk.Model
{
    public class AllLedgers
    {
        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedData Embedded { get; set; }

        public class EmbeddedData
        {
            [JsonProperty("records")]
            public LedgerDetails[] Records { get; set; }
        }
    }
}
