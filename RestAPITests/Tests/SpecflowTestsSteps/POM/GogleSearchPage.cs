using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RestAPITests.Tests.SpecflowTestsSteps.POM
{
    public class GogleSearchPage : BasePage
    {
        public GogleSearchPage(IWebDriver driver) : base(driver)
        {
        }
        
        [FindsBy(How = How.Id, Using = "lst-ib")]
        public IWebElement SerchTextField { get; set; }        

        public IWebElement SearchResultLink(string textToSearch)
        {
            return driver.FindElement(By.XPath($"//a[contains(., '{textToSearch}')]"));            
        }
    }
}
