using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViditureTest.Pages
{

    // Home page contains various static links and content
    // login link to next login page
    class HomePage
    {
        [FindsBy(How = How.LinkText, Using = "OUR STORY")]
        public IWebElement lnkOurStory { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "ABOUT VIDITURE")]
        public IWebElement lnkAbout { get; set; }

        [FindsBy(How = How.TagName, Using = "title")]
        public IWebElement txtTitle { get; set; }

        [FindsBy(How = How.TagName, Using = "iframe")]
        public IWebElement iframeVIdeo { get; set; }

        [FindsBy(How = How.LinkText, Using = "LOGIN")]
        public IWebElement lnkLogin { get; set; }
        
    }
}
