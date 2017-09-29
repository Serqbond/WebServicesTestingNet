using System;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace Framework.HttpUtils
{
    public class RestClient
    {
        private HttpClient Client = new HttpClient();        
        private HttpGetRequest GetRequest;
        HttpOptionsRequest OptionsRequest;

        public RestClient()
        {                 
            InitRestOperations();
        }

        public RestClient(string baseHost)
        {
            Client = new HttpClient(); 
            Client.BaseAddress = new Uri(baseHost);
            InitRestOperations();
        }

        public HttpResponseMessage GetResponse(string requestUri)
        {
            return GetRequest.GetResponse(requestUri);
        }

        public HttpStatusCode GetResponseStatusCode(string requestUri)
        {
            return GetRequest.GetResponseStatusCode(requestUri);
        }

        public T GetResponseAsBusinessEntity<T>(string requestUri) where T : new()
        {
            var result = Client.GetAsync(requestUri).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(result);
        }

        public HttpStatusCode OptionsResponseStatusCode(string requestUri)
        {
            return OptionsRequest.OptionsResponseStatusCode(requestUri);
        }

        private void InitRestOperations()
        {
            GetRequest = new HttpGetRequest(Client);
            OptionsRequest = new HttpOptionsRequest(Client);
        }
    }
}
