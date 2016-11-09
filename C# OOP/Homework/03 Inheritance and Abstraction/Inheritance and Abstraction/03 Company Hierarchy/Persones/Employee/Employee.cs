using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Interfaces;

namespace _03_Company_Hierarchy.Persone.Employee
{
    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private string department;
        protected Employee(string id, string firstName, string lastName, decimal salary, string department) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid salary!");
                }
                this.salary = value;
            }
        }

        public string Department
        {
            get { return this.department; }
            set
            {
                if (value.ToLower() != "production" && value.ToLower() != "accounting" && value.ToLower() != "sales" && value.ToLower() != "marketing")
                {
                    throw new AggregateException("Ivalid department!");
                }
                this.department = value;
            }
        }
    }
}
