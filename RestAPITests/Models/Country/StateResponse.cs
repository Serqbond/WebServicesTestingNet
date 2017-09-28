using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPITests.Models.Country
{
    public class StateResponse
    {        
        [JsonProperty("RestResponse")]
        public CountryResponse CountryResponse { get; set; }
    }
}
