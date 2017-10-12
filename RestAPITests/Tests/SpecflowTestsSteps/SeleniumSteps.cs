using NUnit.Framework;
using OpenQA.Selenium;
using RestAPITests.Tests.SpecflowTestsSteps.POM;
using System;
using TechTalk.SpecFlow;

namespace RestAPITests.Tests.SpecflowTestsSteps
{
    [Binding]
    public class SeleniumSteps
    {
        private IWebDriver driver;
        GogleSearchPage gogleSearchPage;
        BingSearchPage bingSearchPage;

        public SeleniumSteps(IWebDriver driver)
        {
            this.driver = driver;
            gogleSearchPage = new GogleSearchPage(driver);
            bingSearchPage = new BingSearchPage(driver);
        }

        [Given(@"I open page '(.*)'")]
        public void GivenIOpenPage(string ulr)
        {            
            driver.Navigate().GoToUrl(ulr);
            Console.WriteLine("GivenIOpenPage" + System.Threading.Thread.CurrentThread.Name);
        }

        [Given(@"I have entered '(.*)' into the bing search field")]
        public void GivenIHaveEnteredIntoTheBingSearchField(string searchText)
        {
            bingSearchPage.SerchTextField.SendKeys(searchText);
            Console.WriteLine("GivenIHaveEnteredIntoTheBingSearchField" + System.Threading.Thread.CurrentThread.Name);
        }

        [Given(@"I have entered '(.*)' into the search field")]
        public void GivenIHaveEnteredIntoTheSearchField(string searchText)
        {            
            gogleSearchPage.SerchTextField.SendKeys(searchText);
            Console.WriteLine("GivenIHaveEnteredIntoTheSearchField" + System.Threading.Thread.CurrentThread.Name);
        }

        [When(@"I press search button")]
        public void WhenIPressSearchButton()
        {
            gogleSearchPage.SerchTextField.SendKeys("\n");
            Console.WriteLine("WhenIPressSearchButton" + System.Threading.Thread.CurrentThread.Name);
        }

        [When(@"I press search button on the bing page")]
        public void WhenIPressSearchButtonOnTheBingPage()
        {
            bingSearchPage.ButtonSearch.Click();
            Console.WriteLine("WhenIPressSearchButtonOnTheBingPage" + System.Threading.Thread.CurrentThread.Name);
        }

        [Then(@"the result should contain '(.*)' on the bing page")]
        public void ThenTheResultShouldContainOnTheBingPage(string expectedtext)
        {
            Assert.DoesNotThrow(() => bingSearchPage.SearchResultLink(expectedtext));
            Console.WriteLine("ThenTheResultShouldContainOnTheBingPage" + System.Threading.Thread.CurrentThread.Name);
        }


        [Then(@"the result should contain '(.*)'")]
        public void ThenTheResultShouldContain(string expectedtext)
        {
            Assert.DoesNotThrow(() => gogleSearchPage.SearchResultLink(expectedtext));
            Console.WriteLine("ThenTheResultShouldContain" + System.Threading.Thread.CurrentThread.Name);
        }
    }
}
