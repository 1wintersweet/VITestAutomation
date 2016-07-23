using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIAutoFramework.Base;

namespace ViditureTest.Pages
{
    class LoginPage : BasePage
    {
        //public LoginPage(IWebDriver driver) 
        //    :base(driver)
        //{
           
        //}

        // Objects for the login page
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Name, Using = "passwored")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement btnLogin { get; set; }

 
        // login page performs the login operation so place the function here
        // Login and Click login are keyword driven framework in this case.
        // The function names are self explanatory in what operations they refer to. 
        public void Login(string email, string password)
        {        
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
            btnLogin.Submit();          
        }

    }
}
