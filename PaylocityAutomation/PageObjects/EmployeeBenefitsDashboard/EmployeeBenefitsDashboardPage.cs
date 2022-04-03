using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityAutomation
{
    public class EmployeeBenefitsDashboardPage : BasePage
    {
        public EmployeeBenefitsDashboardPage(IWebDriver driver) 
            : base(driver)
        {
            Map = new EmployeeBenefitsDashboardMap(driver);
            Assertions = new EmployeeBenefitsDashboardAssertions(Map);
        }

        public EmployeeBenefitsDashboardMap Map { get; }
        public EmployeeBenefitsDashboardAssertions Assertions { get; }

        protected override string Url => "https://wmxrwq14uc.execute-api.us-east-1.amazonaws.com/Prod/Benefits";

        public IList<string[]> GetExistingEmployees()
        {
            IList<string[]> existingEmployeesInfo = new List<string[]>();

            //Save employees by table row
            IList<IWebElement> existingEmployeesTable = Map.EmployeesTable.FindElements(By.TagName("tr"));

            //Skip the first row since it is the title row
            bool skipTitle = true;

            //Add employee info as strings to a new list for later comparison - this must be done because web elements will go stale
            foreach (IWebElement emp in existingEmployeesTable)
            {
                if (!skipTitle)
                {
                    IList<IWebElement> empInfoWE = emp.FindElements(By.TagName("td"));
                    string[] empInfoArr = new string[] { empInfoWE[0].Text, empInfoWE[1].Text, empInfoWE[2].Text, empInfoWE[3].Text,
                    empInfoWE[4].Text, empInfoWE[5].Text, empInfoWE[6].Text, empInfoWE[7].Text, empInfoWE[8].Text, };

                    existingEmployeesInfo.Add(empInfoArr);
                }
                else
                {
                    skipTitle = false;
                }
            }

            return existingEmployeesInfo;
        }

        public void AddEmployee(EmployeeInfo employee)
        {
            Map.AddEmployeeDashboardButton.Click();
            WaitAndFindElement(By.Id("firstName"));

            Map.AddEmployeeFirstNameInput.SendKeys(employee.FirstName);
            Map.AddEmployeeLastNameInput.SendKeys(employee.LastName);
            Map.AddEmployeeDependantsInput.SendKeys(employee.Dependants.ToString());

            Map.AddEmployeeModalButton.Click();
            WaitForPageLoad();
            WaitForAjax();
        }
    }
}
