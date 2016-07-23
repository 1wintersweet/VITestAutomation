using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIAutoFramework.Base
{
    public class Base
    {
        // this is the base for all pages  - 
        public BasePage CurrentPage { get; set; }
        private IWebDriver _driver { get; set; }

        //Introduce a generic type defintion and it's constraint: https://msdn.microsoft.com/en-us/library/bb384067.aspx
        protected TypeofPage GetInstance<TypeofPage>() where TypeofPage : BasePage,  new()
        {
            TypeofPage pageInstance = new TypeofPage();
        {
                _driver = DriverContext.Driver;
        };
            PageFactory.InitElements(DriverContext.Driver, pageInstance);
            return pageInstance;

    }
        public TypeofPage As<TypeofPage>() where TypeofPage : BasePage
        {
            return (TypeofPage)this;
        }
    }


}
