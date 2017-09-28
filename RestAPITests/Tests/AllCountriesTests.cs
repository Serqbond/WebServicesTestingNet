using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using RestAPITests.Models.AllCountries;
using Newtonsoft.Json;
using NUnit.Framework;
using RestAPITests.Models.Country;

namespace RestAPITests.Tests
{
    [TestFixture]    
    public class AllCountriesTests : FunctionalTest
    {        
        private string BasePath => "/country";        

        [Test]
        public void GetAllCountriesTest()
        {
            Console.WriteLine("GetAllCountriesTest " + System.Threading.Thread.CurrentThread.Name);
            var response = client.GetAsync(BasePath + "/get/all").Result;
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, $"Expected {HttpStatusCode.OK}, but was {response.StatusCode}");
            response = client.SendAsync(new HttpRequestMessage(HttpMethod.Options, BasePath + "/get/all")).Result;
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, $"Expected {HttpStatusCode.OK}, but was {response.StatusCode}");
        }

        [Test]
        public void GetCountryByIsoCode()
        {
            Console.WriteLine("GetCountryByIsoCode " + System.Threading.Thread.CurrentThread.Name);
            var response = client.GetAsync(BasePath + "/get/iso2code/IN").Result.Content.ReadAsStringAsync().Result;            
            AllcountriesResponse allcountriesResponse = JsonConvert.DeserializeObject<AllcountriesResponse>(response);

            Assert.AreEqual("India", allcountriesResponse.RestResponse.Result.First().Name);
        }

        [Test]
        public void NoMatchingCountry()
        {
            Console.WriteLine("NoMatchingCountry " + System.Threading.Thread.CurrentThread.Name);
            var response = client.GetAsync(BasePath + "/get/iso2code/IU").Result.Content.ReadAsStringAsync().Result;
            StateResponse stateResponse = JsonConvert.DeserializeObject<StateResponse>(response);
            Assert.That(stateResponse.CountryResponse.Messages.First(), Does.Contain("More webservices"));
                
            Assert.AreEqual("No matching country found for requested code [IU].", stateResponse.CountryResponse.Messages.Last());
        }        
    }
}
