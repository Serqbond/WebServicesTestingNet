using Framework.HttpUtils;
using NUnit.Framework;
using RestAPITests.Models.Country;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestAPITests.Tests.SpecflowTestsSteps
{
    [Binding]
    public class ApiSearchTestsSteps
    {
        private RestClient restClient;
        private CountryInfo expectedCountryInfo;
        private StateResponse countryServerResponse;
        private CountryInfo actual;

        public ApiSearchTestsSteps(RestClient restClient)
        {
            this.restClient = restClient;
        }   

        [Given(@"I have a CountryInfo object")]
        public void GivenIHaveACountryInfoObject(Table table)
        {
            expectedCountryInfo = table.CreateInstance<CountryInfo>();    
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
        }

        [Then(@"the response is equal to CountryInfo object")]
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