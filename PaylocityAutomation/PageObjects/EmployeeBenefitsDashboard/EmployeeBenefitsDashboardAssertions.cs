using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PaylocityAutomation
{
    public class EmployeeBenefitsDashboardAssertions
    {
        private readonly EmployeeBenefitsDashboardMap _map;

        public EmployeeBenefitsDashboardAssertions(EmployeeBenefitsDashboardMap map)
        {
            _map = map;
        }

        public void AssertNewEmployeeIsPresent(IList<string[]> existingEmployeesInfo, EmployeeInfo newEmployee)
        {
            IList<string[]> currentEmployeesInfo = new List<string[]>();

            //Save employees by table row
            IList<IWebElement> currentEmployees = _map.EmployeesTable.FindElements(By.TagName("tr"));

            //Skip the first row since it is the title row
            bool skipTitle = true;

            //Add employee info as strings to a new list for comparison with the existing employees
            foreach (IWebElement emp in currentEmployees)
            {
                if (!skipTitle)
                {
                    IList<IWebElement> empInfoWE = emp.FindElements(By.TagName("td"));
                    string[] empInfoArr = new string[] { empInfoWE[0].Text, empInfoWE[1].Text, empInfoWE[2].Text, empInfoWE[3].Text,
                        empInfoWE[4].Text, empInfoWE[5].Text, empInfoWE[6].Text, empInfoWE[7].Text, empInfoWE[8].Text, };

                    currentEmployeesInfo.Add(empInfoArr);
                }
                else
                {
                    skipTitle = false;
                }
            }

            //Find the differing employees - we use a lambda function here since both 'Except' and 'Contains' invoke the object's 'Equals'
            //method, which performs a reference equality check rather than comparing the actual contents
            IList<string[]> employeeDiff = new List<string[]>();

            foreach (string[] array in currentEmployeesInfo)
            {
                if (!existingEmployeesInfo.Any(a => a.SequenceEqual(array)))
                {
                    employeeDiff.Add(array);
                }
            }

            //Ensure the differing employee's data matches the employee added
            if (employeeDiff.Count() >= 1)
            {
                bool isNewEmployeePresent = false;
                foreach (string[] addedEmployee in employeeDiff)
                {
                    if (addedEmployee[1] == newEmployee.FirstName &&
                        addedEmployee[2] == newEmployee.LastName &&
                        addedEmployee[3] == newEmployee.Dependants.ToString())
                    {
                        isNewEmployeePresent = true;
                        break;
                    }
                }

                if (!isNewEmployeePresent)
                {
                    throw new AssertionException("The added employee was not found in the employeesTable.");
                }
            }
            else
            {
                throw new AssertionException(String.Format("{0} employees were found when 1 or more were expected.", employeeDiff.Count()));
            }

            Assert.Pass();
        }
    }
}
