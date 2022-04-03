using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityAutomation
{
    public class EmployeeInfo
    {
        public EmployeeInfo(string firstName, string lastName, int dependants)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Dependants = dependants;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Dependants { get; set; }
    }
}
