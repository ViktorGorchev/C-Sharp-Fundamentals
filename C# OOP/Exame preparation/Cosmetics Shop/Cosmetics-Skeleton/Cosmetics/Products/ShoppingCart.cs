using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly IList<IProduct> products = new List<IProduct>();

         
        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            this.products.Remove(product); 
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.products.Contains(product);
        }

        public decimal TotalPrice()
        {
            return products.Sum(product => product.Price);
        }
    }
}
