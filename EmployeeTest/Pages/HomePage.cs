﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIAutoFramework.Base;

namespace ViditureTest.Pages
{

    // Home page contains various static links and content
    // login link to next login page
    class HomePage : BasePage
    {

        // the constructor is only used to pass the webdriver instance.
        // Now base page has the driver/page initialization we can remove page object contructor
        //public HomePage(IWebDriver driver) 
        //    :base(driver)
        //{
           
        //}

        // Objects for the home page
        [FindsBy(How = How.LinkText, Using = "OUR STORY")]
        public IWebElement lnkOurStory { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "ABOUT VIDITURE")]
        public IWebElement lnkAbout { get; set; }

        [FindsBy(How = How.TagName, Using = "title")]
        public IWebElement txtTitle { get; set; }

        [FindsBy(How = How.TagName, Using = "iframe")]
        public IWebElement iframeVIdeo { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.vd-btn.vd-normal-btn")]
        public IWebElement lnkLogin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.vd-btn.vd-confirm-btn")]
        public IWebElement lnkRegister { get; set; }


        public LoginPage ClickLoginLink()
        {
            lnkLogin.Click();
            return new LoginPage();
        }

        public RegisterPage ClickTryForFreeLink()
        {
            lnkRegister.Click();
            return  GetInstance<RegisterPage>();
        }


    }
}
