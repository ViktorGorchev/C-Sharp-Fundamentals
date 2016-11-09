namespace Orders
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using UI;

    public class DataMapper
    {
        public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this.CategoriesFileName = categoriesFileName;
            this.ProductsFileName = productsFileName;
            this.OrdersFileName = ordersFileName;
        }

        public DataMapper()
            : this(
                  "../../DataBase/categories.txt", 
                  "../../DataBase/products.txt", 
                  "../../DataBase/orders.txt")
        {
        }

        /// <summary>
        ///     Gets or sets the categories file name.
        /// </summary>
        public string CategoriesFileName { get; set; }

        /// <summary>
        ///     Gets or sets the products file name.
        /// </summary>
        public string ProductsFileName { get; set; }

        /// <summary>
        ///     Gets or sets the orders file name.
        /// </summary>
        public string OrdersFileName { get; set; }

        public IEnumerable<Category> GetAllCategories()
        {
            var categoryArgs = Reader.ReadFileLines(this.CategoriesFileName, true);
            var category = categoryArgs
                .Select(c => c.Split(','))
                .Select(c => new Category
                {
                    Id = int.Parse(c[0]),
                    Name = c[1],
                    Description = c[2]
                });

            return category;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var productArgs = Reader.ReadFileLines(this.ProductsFileName, true);
            var product = productArgs
                .Select(p => p.Split(','))
                .Select(p => new Product
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    CategoryId = int.Parse(p[2]),
                    UnitPrice = decimal.Parse(p[3]),
                    UnitsInStock = int.Parse(p[4]),
                });

            return product;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orderArgs = Reader.ReadFileLines(this.OrdersFileName, true);
            var order = orderArgs
                .Select(p => p.Split(','))
                .Select(p => new Order
                {
                    Id = int.Parse(p[0]),
                    ProductId = int.Parse(p[1]),
                    Quantity = int.Parse(p[2]),
                    Discount = decimal.Parse(p[3]),
                });

            return order;
        }
    }
}
