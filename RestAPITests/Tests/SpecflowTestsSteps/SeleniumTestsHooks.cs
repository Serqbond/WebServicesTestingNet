using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RestAPITests.Tests.SpecflowTestsSteps
{
    enum Browser
    {
        Chrome = 1,
        IeExplorer = 2,
        Edge = 3
    }

    [Binding, Scope(Tag = "Selenium")]
    public class SeleniumTestsHooks
    {
        private IWebDriver driver;

        private readonly IObjectContainer objectContainer;

        public SeleniumTestsHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Browser browser;
            string ciDiver = Environment.GetEnvironmentVariable("server.driver");

            if (ciDiver == null || ciDiver == "chrome")
            {
                browser = Browser.Chrome;
            }            
            else if (ciDiver == "ieexplorer")
            {
                browser = Browser.IeExplorer;
            }
            else if (ciDiver == "edge")
            {
                browser = Browser.Edge;
            }
            else
            {
                browser = Browser.Chrome;
            }

            switch (browser)
            {
                case Browser.Chrome:
                driver = new ChromeDriver();
                    break;
                case Browser.IeExplorer:
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IgnoreZoomLevel = true;
                    options.PageLoadStrategy = InternetExplorerPageLoadStrategy.Eager;
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    driver = new InternetExplorerDriver(options);
                    break;
                case Browser.Edge:
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.PageLoadStrategy = EdgePageLoadStrategy.Eager;
                    driver = new EdgeDriver(edgeOptions);
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }    
            
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
