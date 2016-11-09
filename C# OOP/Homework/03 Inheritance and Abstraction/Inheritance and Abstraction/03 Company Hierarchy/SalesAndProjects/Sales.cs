using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Interfaces;

namespace _03_Company_Hierarchy.Persone.Employee
{
    public class Sales: ISales
    {
        private const int companyStartYear = 2000;
        private string productName;
        private DateTime date;
        private decimal price;

        public Sales(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid product name!");
                }
                this.productName = value;
            }
        }

        public DateTime Date
        {
            get { return this.date; }
            set
            {
                if (value.Year < companyStartYear)
                {
                    throw new ArgumentOutOfRangeException("Ivalid date of product!");
                }
                this.date = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid price!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Product name: {0}, date: {1}, price: {2}", this.ProductName, this.Date, this.Price + Environment.NewLine);
        }
    }
}
