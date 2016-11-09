using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) 
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }
        public override decimal Price
        {
            get
            {
                return this.Milliliters * base.Price;
            }
        }
        public uint Milliliters { get; }
        public UsageType Usage { get; }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder(base.Print());

            sb.AppendFormat("  * Quantity: {0} ml{1}", this.Milliliters, Environment.NewLine);
            sb.AppendFormat("  * Usage: {0}", this.Usage);

            return sb.ToString();
        }
    }
}
