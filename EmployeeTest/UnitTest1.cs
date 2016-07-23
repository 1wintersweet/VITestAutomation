using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using ViditureTest.Pages;
using VIAutoFramework.Base;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace ViditureTest
{
    [TestClass]
    public class UnitTest1 : Base
    {
        string url = "https://dev.viditure.com/UIFW/#/";
       // public void OpenBrowser(Browser.BrowserType browserType = BrowserType.FireFox) -> pass the default value so we can remove the default case below;
        public void OpenBrowser(Browser.BrowserType browserType)

        {
            switch (browserType)
            {
                case Browser.BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case Browser.BrowserType.FireFox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case Browser.BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                default:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        [TestMethod]
        public void TestLogin()
        {
            OpenBrowser(Browser.BrowserType.FireFox);
            DriverContext.Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(100));
            DriverContext.Browser.GoToUrl(url);
            //DriverContext.Driver = new FirefoxDriver();
          
            //DriverContext.Driver.Navigate().GoToUrl(url);
            Login();
        }

        public void Login()
        {
            //HomePage homePage = new HomePage();
            //LoginPage loginPage = homePage.ClickLoginLink();

            ////Unit test should only consume the page object's methods instead of directly access object itself.
            ////  loginPage.lnkLogin.Click();
            //loginPage.Login("ge_zhang@hotmail.com", "Password!23");

            // use CurrentPage approach

            CurrentPage = GetInstance<HomePage>(); // this function initialize a LoginPage instance and return it;
            CurrentPage =  CurrentPage.As<HomePage>().ClickLoginLink();

            CurrentPage = GetInstance<LoginPage>(); 
            CurrentPage.As<LoginPage>().Login("ge_zhang@hotmail.com", "Password!23");

        }

        [TestMethod]
        public void TestRegister()
        {

            DriverContext.Driver = new FirefoxDriver();
            DriverContext.Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(10000));
            DriverContext.Driver.Navigate().GoToUrl(url);


            Register();
        }
        public void Register()
        {
          //  HomePage homePage = new HomePage();
            // use current page approach to get HomePage
            CurrentPage = GetInstance<HomePage>();
            CurrentPage = CurrentPage.As<HomePage>().ClickTryForFreeLink();
            //  RegisterPage registerPage = homePage.ClickTryForFreeLink();
            // go to RegisterPage
             CurrentPage.As<RegisterPage>().Register();
        }
    }
}
