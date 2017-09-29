using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Framework.HttpUtils
{
    public class StringContentCreator
    {
        public static StringContent Create(object poco)
        {
            return new StringContent(JsonConvert.SerializeObject(poco));
        }
    }
}
