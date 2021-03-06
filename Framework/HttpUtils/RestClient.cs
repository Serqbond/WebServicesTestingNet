﻿using System;
using System.Net.Http;

namespace Framework.HttpUtils
{
    public class RestClient
    {
        public HttpClient Client { get; private set; }
        public HttpGetRequest HttpGetRequest { get; private set; }
        public HttpOptionsRequest HttpOptionsRequest { get; private set; }
        public HttpPostRequest HttpPostRequest { get; private set; }
        public HttpDeleteRequest HttpDeleteRequest { get; private set; }

        public RestClient()
        {                 
            InitRestOperations();
        }

        public RestClient(string baseHost)
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(baseHost)
            };

            InitRestOperations();
        }        

        public void SetNewHost(string hostName)
        {
            Client.BaseAddress = new Uri(hostName);
        }        

        private void InitRestOperations()
        {
            HttpGetRequest = new HttpGetRequest(Client);
            HttpOptionsRequest = new HttpOptionsRequest(Client);
            HttpPostRequest = new HttpPostRequest(Client);
            HttpDeleteRequest = new HttpDeleteRequest(Client);
        }
    }
}
