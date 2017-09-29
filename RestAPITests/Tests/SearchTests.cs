using RestAPITests.Models.Country;
using System;
using System.Linq;
using NUnit.Framework;

namespace RestAPITests.Tests
{
    [TestFixture]
    public class SearchTests : FunctionalTest
    {        
        private string SearchState(string country, string state)
        {            
            return $"/state/search/{country}?text={state}";
        }

        [Test]
        public void SearchByTextInUsa()
        {
            Console.WriteLine("SearchByTextInUsa " + System.Threading.Thread.CurrentThread.Name);

            CountryInfo expectedCountryInfo = new CountryInfo() {
                Abbr = "WA",
                Area = "184661SKM",
                Capital = "Olympia",
                Country = "USA",
                LargestCity = "Seattle",
                Name = "Washington"
            };
            
            StateResponse countryServerResponse = restClient.GetResponseAsBusinessEntity<StateResponse>(SearchState("USA", "wash"));
            
            CountryInfo actual = countryServerResponse.CountryResponse
                .CountryInfo
                .First(country => country.Abbr == expectedCountryInfo.Abbr);

            AssertCountryInfoAreEqual(expectedCountryInfo, actual);
        }

        [Test]
        public void SearchByTextWithIndia()
        {
            Console.WriteLine("SearchByTextWithIndia " + System.Threading.Thread.CurrentThread.Name);

            CountryInfo expectedCountryInfo = new CountryInfo()
            {
                Abbr = "AP",
                Area = "160205SKM",
                Capital = "Hyderabad, India",
                Country = "IND",
                LargestCity = "Visakhapatnam",
                Name = "Andhra Pradesh"
            };
            
            StateResponse countryServerResponse = restClient.GetResponseAsBusinessEntity<StateResponse>(SearchState("IND", "pradesh"));

            CountryInfo actualIndia = countryServerResponse.CountryResponse
                .CountryInfo
                .First(country => country.Abbr == expectedCountryInfo.Abbr);
            AssertCountryInfoAreEqual(expectedCountryInfo, actualIndia);
        }

        private void AssertCountryInfoAreEqual(CountryInfo expected, CountryInfo actual)
        {
            Assert.AreEqual(expected.Abbr, actual.Abbr);
            Assert.AreEqual(expected.Capital, actual.Capital);
            Assert.AreEqual(expected.Area, actual.Area);
            Assert.AreEqual(expected.Country, actual.Country);
            Assert.AreEqual(expected.LargestCity, actual.LargestCity);
            Assert.AreEqual(expected.Name, actual.Name);
        }
    }
}
