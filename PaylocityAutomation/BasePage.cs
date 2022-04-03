using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityAutomation
{
    public abstract class BasePage
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 10;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }

        protected IWebDriver Driver { get; set; }
        protected WebDriverWait WebDriverWait { get; set; }
        protected abstract string Url { get; }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(Url);
            WaitForPageLoad();
            WaitForAjax();
        }

        protected virtual void WaitForPageLoad()
        {
        }

        protected IWebElement? WaitAndFindElement(By locator)
        {
            var element = WebDriverWait.Until(d =>
            {
                var e = d.FindElement(locator);
                if (e.Displayed)
                    return e;
                return null;
            });
            return null;
        }

        protected void WaitForAjax()
        {
            var js = (IJavaScriptExecutor)Driver;
            WebDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
        }

        protected void WaitUntilDocumentReadyState()
        {
            var js = (IJavaScriptExecutor)Driver;
            WebDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
