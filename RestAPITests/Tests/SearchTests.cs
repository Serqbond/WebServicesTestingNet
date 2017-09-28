﻿using Newtonsoft.Json;
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
        private string BasePath => "/state";

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

            string response = client.GetAsync(BasePath + "/search/USA?text=wash").Result.Content.ReadAsStringAsync().Result;

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
