using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViditureTest.Pages
{
    class LoginPage
    {

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Name, Using = "passwored")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".vd-btn, .vd-confirm-btn, .vd-btn-big")]
        public IWebElement btnLogin { get; set; }
    }
}
