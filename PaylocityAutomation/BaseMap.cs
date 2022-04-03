using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityAutomation
{
    public class BaseMap
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 10;
        private WebDriverWait _webDriverWait;

        public BaseMap(IWebDriver driver)
        {
            _webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }

        protected IWebElement? WaitAndFindElement(By locator)
        {
            var element = _webDriverWait.Until(d =>
            {
                var e = d.FindElement(locator);
                if (e.Displayed)
                    return e;
                return null;
            });

            return element;
        }
    }
}
