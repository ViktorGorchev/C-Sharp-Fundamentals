﻿namespace Orders.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Renderer
    {
        public static void PrintMostProfitableCategory(
            IEnumerable<Order> orders,
            IEnumerable<Product> products,
            IEnumerable<Category> categories)
        {
            var category =
                orders.GroupBy(order => order.ProductId)
                    .Select(
                        g =>
                            new
                            {
                                categoryId = products.First(p => p.Id == g.Key).CategoryId,
                                price = products.First(p => p.Id == g.Key).UnitPrice,
                                quantity = g.Sum(p => p.Quantity)
                            })
                    .GroupBy(gg => gg.categoryId)
                    .Select(
                        grp =>
                            new
                            {
                                category_name = categories.First(c => c.Id == grp.Key).Name,
                                total_quantity = grp.Sum(g => g.quantity * g.price)
                            })
                    .OrderByDescending(g => g.total_quantity)
                    .First();
            Console.WriteLine("{0}: {1}", category.category_name, category.total_quantity);
        }

        public static void PrintNumberOfProductsPerCategory(
            IEnumerable<Product> products,
            IEnumerable<Category> categories)
        {
            var numberOfProductsPerCategory =
                products.GroupBy(p => p.CategoryId)
                    .Select(grp => new
                    {
                        Category = categories.First(c => c.Id == grp.Key).Name,
                        Count = grp.Count()
                    })
                    .ToList();
            foreach (var item in numberOfProductsPerCategory)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));
        }

        public static void PrintMostExpensiveProducts(IEnumerable<Product> products, int count)
        {
            var mostExpensiveProducts = products.OrderByDescending(p => p.UnitPrice).Take(count).Select(p => p.Name);
            Console.WriteLine(string.Join(Environment.NewLine, mostExpensiveProducts));

            Console.WriteLine(new string('-', 10));
        }

        public static void PrintMostOrderedProducts(IEnumerable<Order> orders, IEnumerable<Product> products, int count)
        {
            var mostOrderedProducts =
                orders.GroupBy(o => o.ProductId)
                    .Select(
                        group =>
                            new
                            {
                                Product = products.First(p => p.Id == group.Key).Name,
                                Quantity = group.Sum(p => p.Quantity)
                            })
                    .OrderByDescending(q => q.Quantity)
                    .Take(count);
            foreach (var item in mostOrderedProducts)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantity);
            }

            Console.WriteLine(new string('-', 10));
        }
    }
}
