using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCapitalism
{
    public class Company : ICompany
    {
        private string companyName;

        public Company(string companyName)
        {
            this.CompanyName = companyName;
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
    }
}