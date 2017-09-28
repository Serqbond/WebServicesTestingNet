using System;
using NUnit.Framework;
using System.Net.Http;

namespace RestAPITests.Tests
{
    public class FunctionalTest
    {
        protected HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();       
            string baseHost = Environment.GetEnvironmentVariable("server.host");          
            Console.WriteLine(baseHost);

            if (baseHost == null)
            {
                baseHost = "http://services.groupkt.com";
                Uri BaseAddress = new Uri(baseHost);
                client.BaseAddress = BaseAddress;
            }
        }
    }
}
