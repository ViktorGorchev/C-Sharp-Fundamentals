using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndAbstraction
{
    public class Book
    {
        private string title;
        private string auther;
        private decimal price;

        public Book(string title, string auther, decimal price)
        {
            this.Title = title;
            this.Auther = auther;
            this.Price = price;
                
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Enter title.");
                }
                this.title = value;
            }
        }

        public string Auther
        {
            get { return this.auther; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Enter auther.");
                }
                this.auther = value;
            }
        }
        public virtual decimal Price
        {
            get { return this.price; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Price can't be negative number.");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("-Type: Book" + Environment.NewLine +
                "-Title: " + this.Title + Environment.NewLine +
                "-Author: " + this.Auther + Environment.NewLine +
                "-Price: " + this.Price);
            
        }
    }
}
