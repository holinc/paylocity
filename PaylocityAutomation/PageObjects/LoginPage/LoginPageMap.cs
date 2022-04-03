using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityAutomation
{
    public class LoginPageMap : BaseMap
    {
        public LoginPageMap(IWebDriver driver) 
            : base(driver)
        {
        }

        public IWebElement? UsernameTextBox => WaitAndFindElement(By.Id("Username"));
        public IWebElement? PasswordTextBox => WaitAndFindElement(By.Id("Password"));
        public IWebElement? LoginButton => WaitAndFindElement(By.CssSelector("body > div > main > div > div > form > button"));
    }
}
