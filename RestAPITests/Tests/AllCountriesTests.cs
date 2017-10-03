using System;
using System.Linq;
using System.Net;
using RestAPITests.Models.AllCountries;
using NUnit.Framework;
using RestAPITests.Models.Country;

namespace RestAPITests.Tests
{
    [TestFixture]    
    public class AllCountriesTests : FunctionalTest
    {        
        private string BasePath => "/country";
        private string GetAllCountryEndPoint => "/country/get/all";
        private string GetIso2codeEndPoint => "/country/get/iso2code";

        [Test]
        public void GetAllCountriesTest()
        {
            Console.WriteLine("GetAllCountriesTest " + System.Threading.Thread.CurrentThread.Name);
            var response = restClient.HttpGetRequest.
                GetResponseStatusCode(GetAllCountryEndPoint);
            Assert.AreEqual(response, HttpStatusCode.OK, $"Expected {HttpStatusCode.OK}, but was {response}");
            response = restClient.HttpOptionsRequest.
                OptionsResponseStatusCode(GetAllCountryEndPoint);
            Assert.AreEqual(response, HttpStatusCode.OK, $"Expected {HttpStatusCode.OK}, but was {response}");
        }

        [Test]
        public void GetCountryByIsoCode()
        {
            Console.WriteLine("GetCountryByIsoCode " + System.Threading.Thread.CurrentThread.Name);
            AllcountriesResponse allcountriesResponse = restClient.HttpGetRequest
                .GetResponseAsBusinessEntity<AllcountriesResponse>(GetIso2codeEndPoint + "/IN");            
            Assert.AreEqual("India", allcountriesResponse.RestResponse.Result.First().Name);
        }

        [Test]
        public void NoMatchingCountry()
        {
            Console.WriteLine("NoMatchingCountry " + System.Threading.Thread.CurrentThread.Name);
            StateResponse stateResponse = restClient.HttpGetRequest
                .GetResponseAsBusinessEntity<StateResponse>(GetIso2codeEndPoint + "/IU");
                                       
            Assert.AreEqual("No matching country found for requested code [IU].", 
                stateResponse.CountryResponse.Messages.Last());
        }        
    }
}
