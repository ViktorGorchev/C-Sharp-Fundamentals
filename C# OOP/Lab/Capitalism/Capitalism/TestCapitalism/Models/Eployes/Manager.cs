using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestCapitalism
{
    public class Manager : Ceo, IManager
    {
        protected static decimal ManagerSalaryReduction = 0.15m;
        private string departmentName;
        private decimal salary;
        private string position;
        
        public Manager(string companyName, string firstName, string lastName, decimal salary, string departmentName, string position)
           : base(companyName, firstName, lastName, salary)
        {
            this.Salary = salary;
            this.DepartmentName = departmentName;
            this.Position = position;
        }
        
        public override string DepartmentName
        {
            get { return this.departmentName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Ivalid DepartmentName!");
                }
                this.departmentName = value;
            }
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
                this.salary = value * ManagerSalaryReduction;
            }
        }

        public string Position
        {
            get { return this.position; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid position!");
                }
                this.position = value;
            }
        }

        public override string ToString()
        {
            return string.Format("    " + base.ToString());
        }
    }
}