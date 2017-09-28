using Newtonsoft.Json;
using RestAPITests.Models.Country;
using System;
using System.Linq;
using System.Net.Http;
using NUnit.Framework;

namespace RestAPITests.Tests
{
    [TestFixture]
    public class SearchTests : FunctionalTest
    {
        HttpClient client = new HttpClient();
        private Uri BaseAddress => new Uri("http://services.groupkt.com");
        private string BasePath => "/state";

        [Test]
        public void SearchByText()
        {
            Console.WriteLine("SearchByText " + System.Threading.Thread.CurrentThread.Name);

            CountryInfo expectedCountryInfo = new CountryInfo() {
                Abbr = "AP",
                Area = "160205SKM",
                Capital = "Hyderabad, India",
                Country = "IND",
                LargestCity = "Visakhapatnam",
                Name = "Andhra Pradesh"
            };

            client.BaseAddress = BaseAddress;
            string response = client.GetAsync(BasePath + "/search/IND?text=pradesh").Result.Content.ReadAsStringAsync().Result;

            StateResponse countryServerResponse = JsonConvert.DeserializeObject<StateResponse>(response);

            CountryInfo actualIndia = countryServerResponse.CountryResponse
                .CountryInfo
                .First(country => country.Abbr == expectedCountryInfo.Abbr);
            Assert.AreEqual(expectedCountryInfo.Abbr, actualIndia.Abbr);
            Assert.AreEqual(expectedCountryInfo.Capital, actualIndia.Capital);
            Assert.AreEqual(expectedCountryInfo.Area, actualIndia.Area);
            Assert.AreEqual(expectedCountryInfo.Country, actualIndia.Country);
            Assert.AreEqual(expectedCountryInfo.LargestCity, actualIndia.LargestCity);
            Assert.AreEqual(expectedCountryInfo.Name, actualIndia.Name);
        }        
    }
}
