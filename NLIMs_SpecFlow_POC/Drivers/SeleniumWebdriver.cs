using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace NLIMs_SpecFlow_POC.Drivers
{
    public class SeleniumWebdriver
    {
        private IWebDriver driver;
        private readonly ScenarioContext scenarioContext;

        public SeleniumWebdriver(ScenarioContext _scenarioContext)
        {         
            scenarioContext = _scenarioContext;
        }

        public IWebDriver Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            scenarioContext.Set(driver, "WebDriver");
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
