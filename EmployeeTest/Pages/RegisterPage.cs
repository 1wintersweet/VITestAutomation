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

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Name, Using = "confirmpassword")]
        public IWebElement txtConfirmPassword { get; set; }
      
        [FindsBy(How = How.Name, Using = "compname")]
        public IWebElement txtCompanyName { get; set; }


        //dropdown select regnubemp
        // get the select element itself


        //  [FindsBy(How = How.Name, Using = "regnubemp")]   
        // public IWebElement dropdownIndustry { get; set; }



        SelectElement selectIndustry; // = new SelectElement(DriverContext.Driver.FindElement(By.Name("regnubemp")));

        [FindsBy(How = How.Name, Using = "agreeterms")]
        public IWebElement ckhTerm { get; set; }


        [FindsBy(How = How.CssSelector, Using = "button.vd-btn.vd-confirm-btn")]
        public IWebElement btnCreatAccount { get; set; }

      
        public void inputRegisterInfo()
        {

            if (txtFullname.Displayed)
            {
                txtFullname.SendKeys("John Paul");
            }
           
            txtEmail.SendKeys("viditure.test4@gmail.com");
            txtPassword.SendKeys("vidituretest4");
            txtConfirmPassword.SendKeys("vidituretest4");
            txtCompanyName.SendKeys("Test Company 4");


           if ( DriverContext.Driver.FindElement(By.Name("regnubemp")).Displayed)
            {
                selectIndustry  = new SelectElement(DriverContext.Driver.FindElement(By.Name("regnubemp")));
            }


           selectIndustry.SelectByIndex(2);
            ckhTerm.Click();

        }

        public void clickCreateAccount()
        {
            if (btnCreatAccount.Enabled)
            {
              btnCreatAccount.Click();
            }
        }

        public void Register()
        {
            inputRegisterInfo();
           clickCreateAccount();
        }

    }
}
