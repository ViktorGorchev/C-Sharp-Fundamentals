using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCapitalism
{
    public class ChiefTelephoneOfficers : RegularEmployees
    {
        private const decimal ChiefTelephoneOfficersSalaryReduction = 0.02m;
        private decimal salary;
        
        public ChiefTelephoneOfficers(string companyName, string firstName, string lastName, decimal salary,
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
                this.salary = value * (ManagerSalaryReduction - SalaryReduction - ChiefTelephoneOfficersSalaryReduction);
            }
        }
        
    }
}