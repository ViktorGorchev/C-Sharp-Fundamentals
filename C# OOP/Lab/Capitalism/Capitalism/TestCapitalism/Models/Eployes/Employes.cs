using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCapitalism
{
    public abstract class Employes : ICompany
    {
        private string companyName;
        private string firstName;
        private string lastName;
        private decimal salary;
        
        protected Employes(string companyName, string firstName, string lastName, decimal salary)
        {
            this.CompanyName = companyName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;      
        }

        public string CompanyName
        {
            get { return this.companyName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid CompanyName!");
                }
                this.companyName = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AccessViolationException("Invalid FirstName!");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Ivalid LastName!");
                }
                this.lastName = value;
            }
        }
        
        public virtual decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("salary", "Salary can't be negative number!");
                }
                this.salary = value;
            }
        }

        public virtual string DepartmentName { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} ", this.FirstName, this.LastName);
        }
    }
}