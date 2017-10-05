using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Framework.HttpUtils
{
     public class HttpDeleteRequest
    {
        private HttpClient Client { get; set; }

        public HttpDeleteRequest(HttpClient client)
        {
            Client = client;
        }

        public HttpResponseMessage DeleteResponse(string requestUri)
        {
            return Client.DeleteAsync(requestUri).Result;
        }

        public HttpStatusCode DeleteResponseStatusCode(string requestUri)
        {
            return Client.DeleteAsync(requestUri).Result.StatusCode;
        }
    }
}
