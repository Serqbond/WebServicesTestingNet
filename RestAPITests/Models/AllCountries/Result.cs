using Newtonsoft.Json;

namespace RestAPITests.Models.AllCountries
{
    public class Result
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("alpha2_code")]
        public string Alpha2_code { get; set; }
        [JsonProperty(PropertyName = "alpha3_code", NullValueHandling = NullValueHandling.Ignore)]
        public string Alpha3_code { get; set; }

        public Result() { }        

        public override string ToString()
        {
            return Name + " " + Alpha2_code + " " + Alpha3_code;
        }
    }
}
