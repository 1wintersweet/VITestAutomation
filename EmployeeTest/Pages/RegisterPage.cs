using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIAutoFramework.Base;

namespace ViditureTest.Pages 
{
    class RegisterPage : BasePage
    {

        [FindsBy(How = How.Name, Using = "fullname")]
        public IWebElement txtFullname { get; set; }

        [FindsBy(How = How.Name, Using = "regemail")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Name, Using = "passwored")]
        public IWebElement txtPassword { get; set; }


        [FindsBy(How = How.Name, Using = "confirmpassword")]
        public IWebElement txtConfirmPassword { get; set; }
      

        [FindsBy(How = How.Name, Using = "compname")]
        public IWebElement txtCompanyName { get; set; }


        //dropdown select regnubemp
        // get the select element itself
        //https://seleniumhq.github.io/selenium/docs/api/dotnet/

        [FindsBy(How = How.Name, Using = "regnubemp")]

       
        public SelectElement dropdownIndustry { get; set; }

        [FindsBy(How = How.Name, Using = "agreeterms")]
        public IWebElement ckhTerm { get; set; }


        [FindsBy(How = How.CssSelector, Using = "button.vd-btn.vd-normal-btn.vd-btn-big")]
        public IWebElement btnCreatAccount { get; set; }

      
        public void inputRegisterInfo()
        {
            txtFullname.SendKeys("Nancy Stone");
            txtEmail.SendKeys("viditure.test1@gmail.com");
            txtPassword.SendKeys("vidituretest1");
            txtConfirmPassword.SendKeys("vidituretest1");
            txtCompanyName.SendKeys("Test Company 1");
            dropdownIndustry.SelectByIndex(2);
            ckhTerm.Click();

        }

        public void clickCreateAccount()
        {

            btnCreatAccount.Click();

        }

        public void Register()
        {
            inputRegisterInfo();
            clickCreateAccount();
        }

    }
}
