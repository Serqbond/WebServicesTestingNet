using Framework.HttpUtils;
using NUnit.Framework;
using RestAPITests.Models.Country;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace RestAPITests.Tests.SpecflowTestsSteps
{
    [Binding]
    public class SearchTestsSteps
    {
        private RestClient restClient;
        private CountryInfo expectedCountryInfo;
        private StateResponse countryServerResponse;
        private CountryInfo actual;

        [BeforeScenario(Order = 0)]
        public void SetHttpClient()
        {            
            string baseHost = Environment.GetEnvironmentVariable("server.host");

            if (baseHost == null)
            {
                baseHost = "http://services.groupkt.com";
            }

            restClient = new RestClient(baseHost);
        }

        [Given(@"I have a CountryInfo object")]
        public void GivenIHaveACountryInfoObject()
        {
            expectedCountryInfo = new CountryInfo()
            {
                Abbr = "WA",
                Area = "184661SKM",
                Capital = "Olympia",
                Country = "USA",
                LargestCity = "Seattle",
                Name = "Washington"
            };            
        }

        [Given(@"I call service '(.*)' with parameters '(.*)' and '(.*)'")]
        public void GivenICallServiceWithParametersAnd(string path, string country, string state)
        {
            string actualPath = path.Replace("{country}", country).Replace("{state}", state);

            countryServerResponse = restClient
                .HttpGetRequest.
                GetResponseAsBusinessEntity<StateResponse>(actualPath);            
        }

        [When(@"I get response")]
        public void WhenIGetResponse()
        {            
            actual = countryServerResponse.CountryResponse
                .CountryInfo
                .First(country => country.Abbr == expectedCountryInfo.Abbr);

            ScenarioContext.Current.Add("actualCountryInfo", actual);
        }

        [Then(@"the response is equl to CountryInfo object")]
        public void ThenTheResponseIsEqulToCountryInfoObject()
        {
            Assert.AreEqual(expectedCountryInfo.Abbr, actual.Abbr);
            Assert.AreEqual(expectedCountryInfo.Capital, actual.Capital, "Capital is wrong");
            Assert.AreEqual(expectedCountryInfo.Area, actual.Area);
            Assert.AreEqual(expectedCountryInfo.Country, actual.Country);
            Assert.AreEqual(expectedCountryInfo.LargestCity, actual.LargestCity);
            Assert.AreEqual(expectedCountryInfo.Name, actual.Name);
        }
    }
}
