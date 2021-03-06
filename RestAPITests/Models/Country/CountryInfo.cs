﻿using Newtonsoft.Json;

namespace RestAPITests.Models.Country
{
    public class CountryInfo
    {
        [JsonProperty("largest_city")]
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
