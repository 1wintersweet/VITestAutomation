using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace EmployeeTest
{
    [TestClass]
    public class UnitTest1
    {
        string url = "https://dev.viditure.com/beta";

        private IWebDriver _driver;

        [TestMethod]
        public void Test1()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(url);
            ClickLoginLink();
        }

        public void ClickLoginLink()
        {
            _driver.FindElement(By.LinkText("Login")).Click();
          

        }
    }
}
