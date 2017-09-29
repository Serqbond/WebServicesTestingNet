using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace Framework.HttpUtils
{
    public class HttpPostRequest
    {
        private HttpClient Client;

        public HttpPostRequest(HttpClient client)
        {
            Client = client;
        }

        public HttpResponseMessage PostResponse(string requestUri, HttpContent content)
        {            
            return Client.PostAsync(requestUri, content).Result;
        }

        public HttpStatusCode PostResponseStatusCode(string requestUri, HttpContent content)
        {
            return Client.PostAsync(requestUri, content).Result.StatusCode;
        }

        public T PostResponseAsBusinessEntity<T>(string requestUri, HttpContent content) where T : new()
        {
            var result = Client.PostAsync(requestUri, content).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
