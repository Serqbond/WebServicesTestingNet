using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RestAPITests.Tests.SpecflowTestsSteps
{
    [Binding]
    public class SeleniumSteps
    {
        private IWebDriver driver;

        public SeleniumSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I open page '(.*)'")]
        public void GivenIOpenPage(string ulr)
        {            
            driver.Navigate().GoToUrl(ulr);
        }

        [Given(@"I have entered '(.*)' into the search field")]
        public void GivenIHaveEnteredIntoTheSearchField(string searchText)
        {
            var element = driver.FindElement(By.Id("lst-ib"));
            element.SendKeys(searchText);
        }

        [When(@"I press search button")]
        public void WhenIPressSearchButton()
        {            
            var element = driver.FindElement(By.Id("lst-ib"));
            element.SendKeys("\n");
        }

        [Then(@"the result should contain '(.*)'")]
        public void ThenTheResultShouldContain(string expectedtext)
        {
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath($"//a[contains(., '{expectedtext}')]")));
        }
    }
}
