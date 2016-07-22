using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using ViditureTest.Pages;
using VIAutoFramework.Base;

namespace ViditureTest
{
    [TestClass]
    public class UnitTest1
    {
        string url = "https://dev.viditure.com/UIFW/#/";

        private IWebDriver _driver;

        [TestMethod]
        public void Test1()
        {
            DriverContext.Driver = new FirefoxDriver();
            DriverContext.Driver.Navigate().GoToUrl(url);
            Login();
        }


        public void Login()
        {
            //HomePage homePage = new HomePage();
            //homePage.lnkLogin.Click();
            LoginPage loginPage = new LoginPage();
            //Unit test should only consume the page object's methods instead of directly access object itself.
            //  loginPage.lnkLogin.Click();
            loginPage.ClickLoginLink();
            loginPage.Login("dfdf", "dfdfdfd");

        }
    }
}
