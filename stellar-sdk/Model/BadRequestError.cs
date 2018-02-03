using Newtonsoft.Json;

namespace StellarSdk.Model
{
    public class BadRequestError
    {
        [JsonProperty("type")]
        public string PurpleType { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("instance")]
        public string Instance { get; set; }

        //[JsonProperty("extras")]
        //public Extras Extras { get; set; }

        public static BadRequestError FromJson(string json) => JsonConvert.DeserializeObject<BadRequestError>(json, Converter.Settings);

        public static string ToJson(BadRequestError self) => JsonConvert.SerializeObject(self, Converter.Settings);

    }
}
