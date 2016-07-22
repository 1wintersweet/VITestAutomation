using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using ViditureTest.Pages;

namespace ViditureTest
{
    [TestClass]
    public class UnitTest1
    {
        string url = "https://dev.viditure.com/UIFW";

        private IWebDriver _driver;

        [TestMethod]
        public void Test1()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(url);
            Login();
        }


        public void Login()
        {
            HomePage homePage = new HomePage();
            homePage.lnkLogin.Click();

        }
    }
}
