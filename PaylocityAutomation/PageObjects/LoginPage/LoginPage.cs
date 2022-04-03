using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityAutomation
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) 
            : base(driver)
        {
            Map = new LoginPageMap(driver);
            Assertions = new LoginPageAssertions(Map);
        }

        public LoginPageMap Map { get; }
        public LoginPageAssertions Assertions { get; }

        protected override string Url => "https://wmxrwq14uc.execute-api.us-east-1.amazonaws.com/Prod/Account/Login";

        public void FillLoginInfo(UserInfo userInfo)
        {
            Map.UsernameTextBox.SendKeys(userInfo.UserName);
            Map.PasswordTextBox.SendKeys(userInfo.Password);
        }

        public void ClickLogin()
        {
            Map.LoginButton.Click();
            WaitForPageLoad();
            WaitForAjax();
            WaitAndFindElement(By.Id("add"));
        }
    }
}
