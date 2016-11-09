using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Interfaces;

namespace _03_Company_Hierarchy.Persone.Employee
{
    public class Manager : Employee, IManager
    {
        public Manager(string id, string firstName, string lastName, decimal salary, string department) 
            : base(id, firstName, lastName, salary, department)
        {
        }

        public override string ToString()
        {
           
            return string.Format("Manager --> " + base.ToString() + Environment.NewLine + 
                "Department: " + base.Department +", Salary: "+ base.Salary + Environment.NewLine);
        }
    }
}
