using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCapitalism
{
    public abstract class RegularEmployees : Manager
    {
        
        protected static decimal SalaryReduction = 0.01m;
        private decimal salary;
        
        protected RegularEmployees(string companyName, string firstName, string lastName, decimal salary,
            string departmentName, string position) 
            : base(companyName, firstName, lastName, salary, departmentName, position)
        {
            this.Salary = salary;
        }
        
        public override decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("salary", "Salary can't be negative number!");
                }
                this.salary = value * (ManagerSalaryReduction - SalaryReduction);
            }
        }

        public override string ToString()
        {
            return string.Format("    " + base.ToString());
        }
    }
}