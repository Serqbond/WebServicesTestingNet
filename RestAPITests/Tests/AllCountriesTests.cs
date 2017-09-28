using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using RestAPITests.Models.AllCountries;
using Newtonsoft.Json;
using NUnit.Framework;

namespace RestAPITests.Tests
{
    [TestFixture]    
    public class AllCountriesTests : FunctionalTest
    {
        HttpClient client = new HttpClient();
        private Uri BaseAddress => new Uri("http://services.groupkt.com");
        private string BasePath => "/country";
        HttpClient client2 = new HttpClient();

        [Test]
        public void GetAllCountriesTest()
        {
            Console.WriteLine("getAllCountriesTest " + System.Threading.Thread.CurrentThread.Name);
            client.BaseAddress = BaseAddress;
            var response = client.GetAsync(BasePath + "/get/all").Result;
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, $"Expected {HttpStatusCode.OK}, but was {response.StatusCode}");
            response = client.SendAsync(new HttpRequestMessage(HttpMethod.Options, BasePath + "/get/all")).Result;
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, $"Expected {HttpStatusCode.OK}, but was {response.StatusCode}");
        }

        [Test]
        public void GetCountryByIsoCode()
        {
            Console.WriteLine("getAllCountriesTest " + System.Threading.Thread.CurrentThread.Name);
            client2.BaseAddress = BaseAddress;
            var response = client2.GetAsync(BasePath + "/get/iso2code/IN").Result.Content.ReadAsStringAsync().Result;            
            AllcountriesResponse allcountriesResponse = JsonConvert.DeserializeObject<AllcountriesResponse>(response);

            Assert.AreEqual("India", allcountriesResponse.RestResponse.Result.First().Name);
        }        
    }
}
