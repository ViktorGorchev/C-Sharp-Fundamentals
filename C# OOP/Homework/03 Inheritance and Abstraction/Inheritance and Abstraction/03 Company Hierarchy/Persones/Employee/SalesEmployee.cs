using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Interfaces;

namespace _03_Company_Hierarchy.Persone.Employee
{
    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        
        List<Sales> sales = new List<Sales>(); 
        public SalesEmployee(string id, string firstName, string lastName, decimal salary, string department, List<Sales> sales) 
            : base(id, firstName, lastName, salary, department)
        {
            this.Sales = sales;
        }

        public List<Sales> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString() + "Sales count: " + sales.Count + Environment.NewLine);
            sb = sb.Replace("Manager --> ", "Sales employee -- > ");
            foreach (var sale in this.Sales)
            {
               sb.Append(sale);
            }
            return sb.ToString();
            
        }
    }
}
