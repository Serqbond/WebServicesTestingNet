using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPITests.Models.AllCountries
{
    public class Result
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("alpha2_code")]
        public string Alpha2_code { get; set; }
        [JsonProperty("alpha3_code")]
        public string Alpha3_code { get; set; }

        public Result() { }

        public Result(string name, string alpha2_code, string alpha3_code)
        {
            this.Name = name;
            this.Alpha2_code = alpha2_code;
            this.Alpha3_code = alpha3_code;
        }

        public override string ToString()
        {
            return Name + " " + Alpha2_code + " " + Alpha3_code;
        }
    }
}
