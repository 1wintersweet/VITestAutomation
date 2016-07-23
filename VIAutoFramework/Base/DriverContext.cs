using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIAutoFramework.Base
{

    // Instead of having each Page object class to pass driver to the constructor
    // we could have just one static class to maintain that webdriver instance so no need to pass around

    public static class DriverContext
    {
        private static IWebDriver _driver;
        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }

       public static Browser Browser { get; set; }

    }
}
