using BoDi;
using Framework.HttpUtils;
using System;
using TechTalk.SpecFlow;

namespace RestAPITests.Tests.SpecflowTestsSteps
{
    [Binding]
    public sealed class SearchTestsHook
    {       
        private readonly IObjectContainer objectContainer;

        public SearchTestsHook(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string baseHost = Environment.GetEnvironmentVariable("server.host");

            if (baseHost == null)
            {
                baseHost = "http://services.groupkt.com";
            }
            
            var restClient = new RestClient(baseHost);
            objectContainer.RegisterInstanceAs<RestClient>(restClient);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
