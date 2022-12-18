using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NLIMs_SpecFlow_POC.Pages
{
    internal class BasePage
    {
        protected IWebDriver _hmDriver;
        protected By _toasterMessage = By.CssSelector("div[role='alertdialog']");

        public BasePage(IWebDriver hmDriver)
        {
            _hmDriver = hmDriver;
        }

        //Common and custom functions that are being used across all pages
        public IWebElement FindMyElement(By myElement)
        {
            IWebElement WE = _hmDriver.FindElement(myElement);
            return WE;
        }

        public void ClickOn(By webElement)
        {
            _hmDriver.FindElement(webElement).Click();
        }

        public void InsertText(By we, string txt)
        {
            _hmDriver.FindElement(we).SendKeys(txt);
        }

        public void WaitElementToExist(By we, int time)
        {
            WebDriverWait wait0 = new WebDriverWait(_hmDriver, TimeSpan.FromSeconds(time));
            wait0.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(we));
        }

        public string GetToasterMessage()
        {
            WaitElementToExist(_toasterMessage, 30);
            Thread.Sleep(3000);
            string txt = FindMyElement(_toasterMessage).Text;
            return txt;
        }
    }
}
