using TechTalk.SpecFlow;
using NLIMs_SpecFlow_POC.Drivers;
using OpenQA.Selenium;

namespace NLIMs_SpecFlow_POC.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly ScenarioContext scenarioContext;

        public HookInitialization(ScenarioContext _scenarioContext)
        {
            scenarioContext = _scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            SeleniumWebdriver SeleniumDriver = new SeleniumWebdriver(scenarioContext);
            scenarioContext.Set(SeleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Selenium webdriver quit");
            scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}