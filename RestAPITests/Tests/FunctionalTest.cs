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
            Console.WriteLine("Printed if env var exists " + baseHost);

            if (baseHost == null)
            {
                baseHost = "http://services.groupkt.com";
                Console.WriteLine("Printed if env var does not exist " + baseHost);
            }

            Uri BaseAddress = new Uri(baseHost);
            client.BaseAddress = BaseAddress;
        }
    }
}
