using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Framework.HttpUtils
{
    class HttpGetRequest
    {
        private HttpClient Client;

        public HttpGetRequest(HttpClient client)
        {
            Client = client;
        }

        public HttpResponseMessage GetResponse(string requestUri)
        {
            return Client.GetAsync(requestUri).Result;
        }

        public HttpStatusCode GetResponseStatusCode(string requestUri)
        {
            return Client.GetAsync(requestUri).Result.StatusCode;
        }
    }
}
