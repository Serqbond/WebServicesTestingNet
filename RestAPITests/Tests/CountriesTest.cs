using Newtonsoft.Json;
using NUnit.Framework;
using RestAPITests.Models.AllCountries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestAPITests.Tests
{
    [TestFixture]
    public class CountriesTest : FunctionalTest
    {        
        private string BasePath => "/country";

        public static IEnumerable DifferentCountries
        {
            get
            {
                yield return new TestCaseData("Algeria", "DZ", "DZA");
                yield return new TestCaseData("India", "IN", "IND");
                yield return new TestCaseData("Bermuda", "BM", "BMU");
            }
        }        

        [TestCaseSource("DifferentCountries")]
        public void ListContainsSpecifiedCountryResult(string country, string alphacode2, string alphacode3)
        {
            Console.WriteLine("ListContainsSpecifiedCountryResult " + System.Threading.Thread.CurrentThread.Name);
            Result expectedCountry = new Result()
            {
                Name = country, Alpha2_code = alphacode2, Alpha3_code = alphacode3
            };

            string response = client.GetAsync("/country/get/all").Result.Content.ReadAsStringAsync().Result;

            AllcountriesResponse allcountriesResponse = JsonConvert.DeserializeObject<AllcountriesResponse>(response);
            Result actualCountry = allcountriesResponse.RestResponse.Result.First(res => res.Name == country);
            
            Assert.AreEqual(expectedCountry.ToString(), actualCountry.ToString());
        }

    }


}
