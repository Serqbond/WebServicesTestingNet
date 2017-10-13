using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    enum br
    {
        Chrome = 1,
        IeExplorer = 2

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
            br brows = br.Chrome;
            string ciDiver = Environment.GetEnvironmentVariable("server.driver");

            if (ciDiver == null)
            {
                brows = br.Chrome;
            }
            else if (ciDiver == "chrome")
            {
                brows = br.Chrome;
            }
            else if (ciDiver == "ieexplorer")
            {
                brows = br.IeExplorer;
            }

            switch (brows)
            {
                case br.Chrome:
                driver = new ChromeDriver();
                    break;
                case br.IeExplorer:
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IgnoreZoomLevel = true;
                    options.PageLoadStrategy = InternetExplorerPageLoadStrategy.Eager;
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    driver = new InternetExplorerDriver(options);
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
