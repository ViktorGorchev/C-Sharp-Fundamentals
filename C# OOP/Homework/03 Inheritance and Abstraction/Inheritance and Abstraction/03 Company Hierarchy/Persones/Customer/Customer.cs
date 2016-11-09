using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Interfaces;

namespace _03_Company_Hierarchy.Persone.Customer
{
    public class Customer : Person, ICustomer
    {
        private decimal netPurchaseAmount;
        public Customer(string id, string firstName, string lastName, decimal netPurchaseAmount) 
            : base(id, firstName, lastName)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public decimal NetPurchaseAmount
        {
            get { return this.netPurchaseAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid net purchase ampunt!");
                }
                this.netPurchaseAmount = value;
            }
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + Environment.NewLine + "Net purchase amount: " + this.netPurchaseAmount);
        }
    }
}
