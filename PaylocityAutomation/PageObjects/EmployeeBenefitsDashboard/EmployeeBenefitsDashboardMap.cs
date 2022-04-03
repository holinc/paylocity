using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityAutomation
{
    public class EmployeeBenefitsDashboardMap : BaseMap
    {
        public EmployeeBenefitsDashboardMap(IWebDriver driver) 
            : base(driver)
        {
        }

        public IWebElement? AddEmployeeDashboardButton => WaitAndFindElement(By.Id("add"));
        public IWebElement? EmployeesTable => WaitAndFindElement(By.Id("employeesTable"));
        public IWebElement? LogOutLink => WaitAndFindElement(By.PartialLinkText(@"/Prod/Account/LogOut"));
        public IWebElement? AddEmployeeFirstNameInput => WaitAndFindElement(By.Id("firstName"));
        public IWebElement? AddEmployeeLastNameInput => WaitAndFindElement(By.Id("lastName"));
        public IWebElement? AddEmployeeDependantsInput => WaitAndFindElement(By.Id("dependants"));
        public IWebElement? AddEmployeeModalButton => WaitAndFindElement(By.Id("addEmployee"));
    }
}
