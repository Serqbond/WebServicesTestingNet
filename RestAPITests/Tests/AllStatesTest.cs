using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Net;
using RestAPITests.Models.Country;

namespace RestAPITests.Tests
{
    public class AllStatesTest : FunctionalTest
    {        
        private string BasePath => "/state";

        [Test]
        public void GetStatusCodeTestCase()
        {
            Console.WriteLine("GetStatusCodeTestCase " + System.Threading.Thread.CurrentThread.Name);
            var actualStatusCode = client.GetAsync(BasePath + "/get/IND/UP").Result.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, actualStatusCode);            
        }

        [Test]
        public void GetCapitalWorks()
        {
            Console.WriteLine("GetCapitalWorks " + System.Threading.Thread.CurrentThread.Name);
            var actualCountryInfo = client.GetAsync(BasePath + "/get/IND/UP").Result.Content.ReadAsStringAsync().Result;
            StateResponse sp = JsonConvert.DeserializeObject<StateResponse>(actualCountryInfo);
            Assert.That(sp.CountryResponse.CountryInfo.First().Capital, Is.EqualTo("Lucknow"));
        }

        [Test]
        public void GetJsonBody()
        {
            Console.WriteLine("GetJsonBody " + System.Threading.Thread.CurrentThread.Name);
            string response = client.GetAsync(BasePath + "/get/IND/UP").Result.Content.ReadAsStringAsync().Result;
            StateResponse stateResponse = JsonConvert.DeserializeObject<StateResponse>(response);
            Assert.AreEqual("Lucknow", stateResponse.CountryResponse.CountryInfo.First().Capital);
        }

        [Test]
        public void GetJsonBodyAndOtherHost()
        {
            Console.WriteLine("GetJsonBodyAndOtherHost " + System.Threading.Thread.CurrentThread.Name);
            string response = client.GetAsync(BasePath + "/get/IND/UP").Result.Content.ReadAsStringAsync().Result;
            StateResponse stateResponse = JsonConvert.DeserializeObject<StateResponse>(response);
            Assert.AreEqual("Lucknow", stateResponse.CountryResponse.CountryInfo.First().Capital);

            HttpClient rest = new HttpClient();
            rest.BaseAddress = new Uri("http://api.openweathermap.org");
            var actualStatus = rest.GetAsync("/data/2.5/weather?lat=35&lon=139").Result.StatusCode;
            Assert.AreEqual(HttpStatusCode.Unauthorized, actualStatus);
        }
}
}
