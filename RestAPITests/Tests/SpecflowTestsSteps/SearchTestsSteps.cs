using Framework.HttpUtils;
using NUnit.Framework;
using RestAPITests.Models.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RestAPITests.Tests.SpecflowTestsSteps
{
    [Binding]
    public class SearchTestsSteps
    {
        [BeforeScenario(Order = 0)]
        public void SetHttpClient()
        {            
            string baseHost = Environment.GetEnvironmentVariable("server.host");

            if (baseHost == null)
            {
                baseHost = "http://services.groupkt.com";
            }

            var restClient = new RestClient(baseHost);
            ScenarioContext.Current.Add("HttpClient", restClient);
        }

        [Given(@"I have a CountryInfo object")]
        public void GivenIHaveACountryInfoObject()
        {
            CountryInfo expectedCountryInfo = new CountryInfo()
            {
                Abbr = "WA",
                Area = "184661SKM",
                Capital = "Olympia",
                Country = "USA",
                LargestCity = "Seattle",
                Name = "Washington"
            };

            ScenarioContext.Current.Add("expectedCountryInfo", expectedCountryInfo);
        }

        [Given(@"I call service '(.*)' with parameters '(.*)' and '(.*)'")]
        public void GivenICallServiceWithParametersAnd(string path, string country, string state)
        {
            string actualPath = path.Replace("{country}", country).Replace("{state}", state);

            StateResponse countryServerResponse = ((RestClient)ScenarioContext.Current["HttpClient"])
                .HttpGetRequest.
                GetResponseAsBusinessEntity<StateResponse>(actualPath);

            ScenarioContext.Current.Add("countryServerResponse", countryServerResponse);
        }

        [When(@"I get response")]
        public void WhenIGetResponse()
        {
            var countryServerResponse = ((StateResponse)ScenarioContext.Current["countryServerResponse"]);
            
            CountryInfo actual = countryServerResponse.CountryResponse
                .CountryInfo
                .First(country => country.Abbr == ((CountryInfo)ScenarioContext.Current["expectedCountryInfo"]).Abbr);

            ScenarioContext.Current.Add("actualCountryInfo", actual);
        }

        [Then(@"the response is equl to CountryInfo object")]
        public void ThenTheResponseIsEqulToCountryInfoObject()
        {
            var expected = (CountryInfo)ScenarioContext.Current["expectedCountryInfo"];
            var actual = (CountryInfo)ScenarioContext.Current["actualCountryInfo"];

            Assert.AreEqual(expected.Abbr, actual.Abbr);
            Assert.AreEqual(expected.Capital, actual.Capital, "Capital is wrong");
            Assert.AreEqual(expected.Area, actual.Area);
            Assert.AreEqual(expected.Country, actual.Country);
            Assert.AreEqual(expected.LargestCity, actual.LargestCity);
            Assert.AreEqual(expected.Name, actual.Name);
        }

    }
}
