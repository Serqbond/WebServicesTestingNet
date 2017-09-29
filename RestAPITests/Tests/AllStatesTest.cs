using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Net;
using RestAPITests.Models.Country;
using Framework.HttpUtils;

namespace RestAPITests.Tests
{
    public class AllStatesTest : FunctionalTest
    {        
        private string BasePath => "/state";

        [Test]
        public void GetStatusCodeTestCase()
        {
            Console.WriteLine("GetStatusCodeTestCase " + System.Threading.Thread.CurrentThread.Name);
            Assert.AreEqual(HttpStatusCode.OK, restClient.GetResponseStatusCode(BasePath + "/get/IND/UP"));            
        }

        [Test]
        public void GetCapitalWorks()
        {
            Console.WriteLine("GetCapitalWorks " + System.Threading.Thread.CurrentThread.Name);
            StateResponse sp = restClient.GetResponseAsBusinessEntity<StateResponse>(BasePath + "/get/IND/UP");
            Assert.That(sp.CountryResponse.CountryInfo.First().Capital, Is.EqualTo("Lucknow"));
        }

        [Test]
        public void GetJsonBody()
        {
            Console.WriteLine("GetJsonBody " + System.Threading.Thread.CurrentThread.Name);
            StateResponse stateResponse = restClient.GetResponseAsBusinessEntity<StateResponse>(BasePath + "/get/IND/UP");
            Assert.AreEqual("Lucknow", stateResponse.CountryResponse.CountryInfo.First().Capital);
        }

        [Test]
        public void GetJsonBodyAndOtherHost()
        {
            Console.WriteLine("GetJsonBodyAndOtherHost " + System.Threading.Thread.CurrentThread.Name);
            StateResponse stateResponse = restClient.GetResponseAsBusinessEntity<StateResponse>(BasePath + "/get/IND/UP");
            Assert.AreEqual("Lucknow", stateResponse.CountryResponse.CountryInfo.First().Capital);
            
            RestClient rest = new RestClient("http://api.openweathermap.org");
            Assert.AreEqual(HttpStatusCode.Unauthorized,
                new RestClient("http://api.openweathermap.org")
                .GetResponseStatusCode("/data/2.5/weather?lat=35&lon=139"));
        }
}
}
