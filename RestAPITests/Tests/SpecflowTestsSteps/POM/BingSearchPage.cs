using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPITests.Tests.SpecflowTestsSteps.POM
{
    public class BingSearchPage
    {
        private IWebDriver driver;

        public BingSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "sb_form_q")]
        public IWebElement SerchTextField { get; set; }

        [FindsBy(How = How.Id, Using = "sb_form_go")]
        public IWebElement ButtonSearch { get; set; }

        public IWebElement SearchResultLink(string textToSearch)
        {
            return driver.FindElement(By.XPath($"//cite[contains(., '{textToSearch}')]"));
        }
    }
}
