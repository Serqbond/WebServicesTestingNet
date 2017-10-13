using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RestAPITests.Tests.SpecflowTestsSteps.POM;
using System;
using TechTalk.SpecFlow;

namespace RestAPITests.Tests.SpecflowTestsSteps
{    
    [Binding]
    public class SeleniumSearchTestSteps
    {
        private IWebDriver driver;
        GogleSearchPage gogleSearchPage;
        BingSearchPage bingSearchPage;

        public SeleniumSearchTestSteps(IWebDriver driver)
        {
            this.driver = driver;
            gogleSearchPage = new GogleSearchPage(driver);
            bingSearchPage = new BingSearchPage(driver);
        }

        [Given(@"I open page '(.*)'")]
        public void GivenIOpenPage(string ulr)
        {            
            driver.Navigate().GoToUrl(ulr);
        }

        [Given(@"I have entered '(.*)' into the bing search field")]
        public void GivenIHaveEnteredIntoTheBingSearchField(string searchText)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(bingSearchPage.SerchTextField));
            bingSearchPage.SerchTextField.SendKeys(searchText);
        }

        [Given(@"I have entered '(.*)' into the search field")]
        public void GivenIHaveEnteredIntoTheSearchField(string searchText)
        {            
            gogleSearchPage.SerchTextField.SendKeys(searchText);
        }

        [When(@"I press search button on google page")]
        public void WhenIPressSearchButton()
        {
            gogleSearchPage.SerchTextField.SendKeys("\n");
        }

        [When(@"I press search button on the bing page")]
        public void WhenIPressSearchButtonOnTheBingPage()
        {
            bingSearchPage.ButtonSearch.Click();
        }

        [Then(@"the result should contain '(.*)' on the bing page")]
        public void ThenTheResultShouldContainOnTheBingPage(string expectedtext)
        {
            Assert.DoesNotThrow(() => bingSearchPage.SearchResultLink(expectedtext));
        }


        [Then(@"the result should contain '(.*)'")]
        public void ThenTheResultShouldContain(string expectedtext)
        {
            Assert.DoesNotThrow(() => gogleSearchPage.SearchResultLink(expectedtext));
        }
    }
}
