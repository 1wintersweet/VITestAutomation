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

        //[TestMethod]
        //public void TestLogin()
        //{
        //    DriverContext.Driver = new FirefoxDriver();
        //    DriverContext.Driver.Navigate().GoToUrl(url);
        //    Login();
        //}

        //public void Login()
        //{
        //    HomePage homePage = new HomePage();
        //    LoginPage loginPage = homePage.ClickLoginLink();
          
        //    //Unit test should only consume the page object's methods instead of directly access object itself.
        //    //  loginPage.lnkLogin.Click();
        //    loginPage.Login("ge_zhang@hotmail.com", "Password!23");

        //}

        [TestMethod]
        public void TestRegister()
        {
            DriverContext.Driver = new FirefoxDriver();
            DriverContext.Driver.Navigate().GoToUrl(url);
            Register();
        }
        public void Register()
        {
            HomePage homePage = new HomePage();
            RegisterPage registerPage = homePage.ClickTryForFreeLink();
            registerPage.Register();
        }


    }
}
