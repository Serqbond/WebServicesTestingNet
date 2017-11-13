using System;
using NUnit.Framework;
using System.Net.Http;
using Framework.HttpUtils;

namespace RestAPITests.Tests
{
    public class FunctionalTest
    {        
        protected RestClient restClient;

        [SetUp]
        public void Setup()
        {
            string baseHost = Environment.GetEnvironmentVariable("server.host");            

            if (baseHost == null)
            {
                baseHost = "http://services.groupkt.com";
            }

            restClient = new RestClient(baseHost);
        }
    }
}
