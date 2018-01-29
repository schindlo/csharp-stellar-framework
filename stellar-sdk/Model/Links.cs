using Newtonsoft.Json;

namespace StellarSdk.Model
{
    public partial class Links
    {
        [JsonProperty("self")]
        public Self Self { get; set; }

        [JsonProperty("transactions")]
        public LinksData Transactions { get; set; }

        [JsonProperty("operations")]
        public LinksData Operations { get; set; }

        [JsonProperty("payments")]
        public LinksData Payments { get; set; }

        [JsonProperty("effects")]
        public LinksData Effects { get; set; }

        [JsonProperty("offers")]
        public LinksData Offers { get; set; }

        [JsonProperty("trades")]
        public LinksData Trades { get; set; }

        [JsonProperty("data")]
        public LinksData Data { get; set; }
    }
}
