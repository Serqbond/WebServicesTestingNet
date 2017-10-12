using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RestAPITests.Tests.SpecflowTestsSteps.POM
{
    public class GogleSearchPage
    {
        private IWebDriver driver;

        public GogleSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.Id, Using = "lst-ib")]
        public IWebElement SerchTextField { get; set; }

        public IWebElement SearchResultLink(string textToSearch)
        {
            return driver.FindElement(By.XPath($"//a[contains(., '{textToSearch}')]"));
        }
    }
}
