using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using RestAPITests.Models.AllCountries;
using Newtonsoft.Json;
using NUnit.Framework;

namespace RestAPITests.Tests
{
    [TestFixture]
    public class CountryListTest : FunctionalTest
    {        
        private string CountryGetAll => "/country/get/all";

        [Test]
        public void ListContainsUkraine()
        {
            Console.WriteLine("ListContainsUkraine " + System.Threading.Thread.CurrentThread.Name);
            AllcountriesResponse allcountriesResponse = restClient.HttpGetRequest.
                GetResponseAsBusinessEntity<AllcountriesResponse>(CountryGetAll);                
            Assert.AreEqual("UA", allcountriesResponse.RestResponse.Result.First(country => country.Name == "Ukraine").Alpha2_code);
        }

        [Test]
        public void ListContainsAlgeriaResult()
        {
            Console.WriteLine("ListContainsAlgeriaResult " + System.Threading.Thread.CurrentThread.Name);
            Result expectedAlgeria = new Result() {Name = "Algeria", Alpha2_code = "DZ", Alpha3_code = "DZA"};
            AllcountriesResponse allcountriesResponse = restClient.HttpGetRequest.
                GetResponseAsBusinessEntity<AllcountriesResponse>(CountryGetAll);
            Result actualAlgeria = allcountriesResponse.RestResponse.Result.First(country => country.Name == "Algeria");
            Assert.AreEqual(expectedAlgeria.ToString(), actualAlgeria.ToString());
        }
    }
}

