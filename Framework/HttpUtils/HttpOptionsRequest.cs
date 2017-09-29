using System.Net;
using System.Net.Http;

namespace Framework.HttpUtils
{
    public class HttpOptionsRequest
    {
        private HttpClient Client;

        public HttpOptionsRequest(HttpClient client)
        {
            Client = client;
        }

        public HttpResponseMessage OptionsResponse(string requestUri)
        {
            return Client.SendAsync(new HttpRequestMessage(HttpMethod.Options, requestUri)).Result;
        }

        public HttpStatusCode OptionsResponseStatusCode(string requestUri)
        {
            return Client.SendAsync(new HttpRequestMessage(HttpMethod.Options, requestUri)).Result.StatusCode;
        }
    }
}
