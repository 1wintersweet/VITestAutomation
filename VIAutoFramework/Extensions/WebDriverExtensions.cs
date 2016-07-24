using OpenQA.Selenium;
using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIAutoFramework.Extensions
{
    public static class WebDriverExtensions
    {

        public static void WaitforPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition()
        }

        // ie javascript interface in Selenium
        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };
            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }

        }
    }
}
