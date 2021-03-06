﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VIAutoFramework.Extensions
{
   public static class WebElementExtensions
    {

        public static string GetSelectedDropdown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();

        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;

        }


        public static void SelectDropDownList(this IWebElement element, string value)
        {
            SelectElement  ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
            {
                throw new Exception(string.Format("Elemet Not Present exception"));
            }
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
