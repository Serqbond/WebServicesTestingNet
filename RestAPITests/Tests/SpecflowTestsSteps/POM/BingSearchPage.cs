using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RestAPITests.Tests.SpecflowTestsSteps.POM
{
    public class BingSearchPage : BasePage
    {
        public BingSearchPage(IWebDriver driver) : base(driver)
        {                       
        }

        [FindsBy(How = How.Id, Using = "sb_form_q")]
        public IWebElement SerchTextField { get; set; }

        [FindsBy(How = How.Id, Using = "sb_form_go")]
        public IWebElement ButtonSearch { get; set; }

        public IWebElement SearchResultLink(string textToSearch)
        {
            return driver.FindElement(By.XPath($"//cite[contains(., '{textToSearch}')]"));
        }

        public IWebElement Boo()
        {
            return driver.FindElement(By.CssSelector(""));
        }
    }
}
