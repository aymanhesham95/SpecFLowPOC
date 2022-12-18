using OpenQA.Selenium;
using System.Configuration;

namespace NLIMs_SpecFlow_POC.Pages
{
    internal class LoginPage : BasePage
    {
        //webelements need for login 
        private By _username = By.Name("username");
        private By _password = By.Name("password");
        private By _loginNlims = By.XPath("//span[text()='Login']");
        

        public LoginPage(IWebDriver _lpDriver) : base(_lpDriver)
        {
        }

        //Actions and steps that are used based on the element locators

        public void NavigateToLoginPage()
        {
            _hmDriver.Url = "https://qc.neuro-ace.net/account/login";
        }

        public void InsertUserName(string username_para)
        {
            InsertText(_username, username_para);
        }

        public void InsertPassword(string password_para)
        {
            InsertText(_password, password_para);
        }

        public void ClickOnLoginButton()
        {
            WaitElementToExist(_loginNlims, 5);
            ClickOn(_loginNlims);
        }

        
    }
}
