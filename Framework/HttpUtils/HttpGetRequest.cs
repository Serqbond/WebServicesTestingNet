using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace Framework.HttpUtils
{
    public class HttpGetRequest
    {
        private HttpClient Client { get; set; }

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

        public T GetResponseAsBusinessEntity<T>(string requestUri) where T : new()
        {
            var result = Client.GetAsync(requestUri).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(result, 
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore }
                );
        }
    }
}
