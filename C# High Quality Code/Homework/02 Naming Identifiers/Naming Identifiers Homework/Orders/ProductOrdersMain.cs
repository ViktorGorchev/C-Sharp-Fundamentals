namespace Orders
{
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Models;
    using UI;

    public class ProductOrdersMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new DataMapper();

            var allCategories = dataMapper.GetAllCategories();
            var categories = allCategories as Category[] ?? allCategories.ToArray();

            var allProducts = dataMapper.GetAllProducts();
            var products = allProducts as Product[] ?? allProducts.ToArray();

            var allOrders = dataMapper.GetAllOrders();
            var orders = allOrders as Order[] ?? allOrders.ToArray();
            
            // Names of the 5 most expensive products
            Renderer.PrintMostExpensiveProducts(products, 5);

            // Number of products in each category
            Renderer.PrintNumberOfProductsPerCategory(products, categories);

            // The 5 top products (by order quantity)
            Renderer.PrintMostOrderedProducts(orders, products, 5);

            // The most profitable category
            Renderer.PrintMostProfitableCategory(orders, products, categories);
        }
    }
}
