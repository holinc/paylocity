using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaylocityAutomation
{
    public class PctyTests : IDisposable
    {
        private static IWebDriver _driver;
        private static LoginPage _loginPage;
        private static EmployeeBenefitsDashboardPage _employeesPage;

        public PctyTests()
        {
            _driver = new ChromeDriver(@".\Drivers\");
            _driver.Manage().Window.Maximize();
            _loginPage = new LoginPage(_driver);
            _employeesPage = new EmployeeBenefitsDashboardPage(_driver);
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

        [Test, Order(1)]
        public void TestLogin()
        {
            UserInfo userInfo = new UserInfo("USERNAME", "PASSWORD");

            _loginPage.GoTo();
            _loginPage.FillLoginInfo(userInfo);
            _loginPage.Assertions.AssertUsernameEntered("USERNAME");

            _loginPage.ClickLogin();
        }

        [Test, Order(2)]
        public void TestAddEmployee()
        {
            IList<string[]> existingEmployeesInfo = new List<string[]>();
            EmployeeInfo newEmployee = new EmployeeInfo("foo", "bar", 1);

            existingEmployeesInfo = _employeesPage.GetExistingEmployees();
            _employeesPage.AddEmployee(newEmployee);
            _employeesPage.Assertions.AssertNewEmployeeIsPresent(existingEmployeesInfo, newEmployee);
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
            Dispose();
            _driver.Close();
        }
    }
}