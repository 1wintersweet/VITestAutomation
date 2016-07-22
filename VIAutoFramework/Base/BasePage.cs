using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIAutoFramework.Base
{

    // This class is the base for all Viditure page object classes
   public abstract class BasePage
    {
     
        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }


    }
}
