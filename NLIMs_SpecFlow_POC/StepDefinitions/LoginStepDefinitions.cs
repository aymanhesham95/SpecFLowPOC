using System;
using TechTalk.SpecFlow;
using NLIMs_SpecFlow_POC.Pages;
using NLIMs_SpecFlow_POC.Drivers;
using OpenQA.Selenium;
using NUnit.Framework;

namespace NLIMs_SpecFlow_POC.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        
        public IWebDriver myDriver;
        private readonly ScenarioContext scenarioContext;
        private LoginPage loginPage;
        private By _librarySynthesisTitle = By.XPath("(//h3[normalize-space()='Library Syntheses'])[1]");

        public LoginStepDefinitions(ScenarioContext _scenarioContext)
        {
            scenarioContext = _scenarioContext;
            myDriver = scenarioContext.Get<SeleniumWebdriver>("SeleniumDriver").Setup();
            loginPage = new LoginPage(myDriver);
        }


        [Given(@"User navigates to NLIMs login Page")]
        public void GivenUserNavigatesToNLIMsLoginPage()
        {
            loginPage.NavigateToLoginPage();       
        }

        [When(@"User enters Valid Username")]
        public void WhenUserEntersValidUsername()
        {
            loginPage.InsertUserName("AymanAdmin");
        }

        [When(@"User enters Valid Password")]
        public void WhenUserEntersValidPassword()
        {
            loginPage.InsertPassword("P@ssw0rd1995");
        }

        [Then(@"User should be logged in to the system")]
        public void ThenUserShouldBeLoggedInToTheSystem()
        {
            Thread.Sleep(3000);
            //loginPage.WaitElementToExist(_librarySynthesisTitle,45);
            String Actual = loginPage.FindMyElement(_librarySynthesisTitle).Text;
            Assert.That(Actual, Is.EqualTo("Library Syntheses"));
        }

        [When(@"User enters Invalid Username")]
        public void WhenUserEntersInvalidUsername()
        {
            loginPage.InsertUserName("Wrong Username");
        }

        [When(@"User enters Invalid Password")]
        public void WhenUserEntersInvalidPassword()
        {
            loginPage.InsertPassword("Wrong Password");
        }

        [Then(@"An error Msg should be displayed")]
        public void ThenAnErrorMsgShouldBeDisplayed()
        {
            Assert.AreEqual("Incorrect username or password", loginPage.GetToasterMessage());
        }

        [When(@"Click on Login Button")]
        public void WhenClickOnLoginButton()
        {
            loginPage.ClickOnLoginButton();
        }

    }
}
