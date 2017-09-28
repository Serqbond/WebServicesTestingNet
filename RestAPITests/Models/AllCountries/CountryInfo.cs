using Newtonsoft.Json;

namespace RestAPITests.Models
{
    public class CountryInfo
    {
        [JsonProperty("largestCity")]
        public string LargestCity { get; set; }
        [JsonProperty("area")]
        public string Area { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("abbr")]
        public string Abbr { get; set; }
        [JsonProperty("capital")]
        public string Capital { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
