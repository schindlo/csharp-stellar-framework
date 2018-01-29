using Newtonsoft.Json;

namespace StellarSdk.Model
{
    public partial class AccountBalance
    {
        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("asset_type")]
        public string AssetType { get; set; }
    }
}
