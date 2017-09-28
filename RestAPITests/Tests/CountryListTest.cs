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
        HttpClient client = new HttpClient();
        private Uri BaseAddress => new Uri("http://services.groupkt.com");
        private string BasePath => "/country";
        HttpClient client2 = new HttpClient();

        [Test]
        public void ListContainsUkraine()
        {
            Console.WriteLine("ListContainsUkraine " + System.Threading.Thread.CurrentThread.Name);
            client.BaseAddress = BaseAddress;
            var response = client.GetAsync(BasePath + "/get/all").Result.Content.ReadAsStringAsync().Result;
            AllcountriesResponse allcountriesResponse = JsonConvert.DeserializeObject<AllcountriesResponse>(response);
            Assert.AreEqual("UA", allcountriesResponse.RestResponse.Result.First(country => country.Name == "Ukraine").Alpha2_code);
        }

        [Test]
        public void ListContainsAlgeriaResult()
        {
            Console.WriteLine("ListContainsAlgeriaResult " + System.Threading.Thread.CurrentThread.Name);
            Result expectedAlgeria = new Result("Algeria", "DZ", "DZA");
            client2.BaseAddress = BaseAddress;
            var response = client2.GetAsync(BasePath + "/get/all").Result.Content.ReadAsStringAsync().Result;
            AllcountriesResponse allcountriesResponse = JsonConvert.DeserializeObject<AllcountriesResponse>(response);
            Result actualAlgeria = allcountriesResponse.RestResponse.Result.First(country => country.Name == "Algeria");
            Assert.AreEqual(expectedAlgeria.ToString(), actualAlgeria.ToString());
        }
    }
}

