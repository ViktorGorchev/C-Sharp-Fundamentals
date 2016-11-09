using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndAbstraction
{
    public class GoldenEditionBook : Book
    {
        private const double Percent = 1.3;

        public GoldenEditionBook(string title, string auther, decimal price)
            : base(title, auther, price)
        {
        }

        public override decimal Price
        {
            get
            {
                return base.Price * (decimal)Percent;
            }
        }

        public override string ToString()
        {
            return string.Format("-Type: GoldenEditionBook" + Environment.NewLine +
                                 "-Title: " + this.Title + Environment.NewLine +
                                 "-Author: " + this.Auther + Environment.NewLine +
                                 "-Price: " + this.Price);
        }
    }
}