using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCapitalism
{
    public class CleaningLady : RegularEmployees
    {
        private const decimal CleaningLadySalaryReduction = 0.02m;
        private decimal salary;
        
        public CleaningLady(string companyName, string firstName, string lastName, decimal salary,
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
                this.salary = value * (ManagerSalaryReduction - SalaryReduction - CleaningLadySalaryReduction);
            }
        }
    }
}