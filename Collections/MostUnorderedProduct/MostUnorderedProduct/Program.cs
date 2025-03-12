using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostUnorderedProduct
{
    public class Order
    {
        public string ProductName { get; set; }
        public int QuantityOrdered { get; set; }

        public Order(string productName, int quantityOrdered)
        {
            ProductName = productName;
            QuantityOrdered = quantityOrdered;
        }

        public override string ToString()
        {
            return $"Product: {ProductName}, Quantity: {QuantityOrdered}";
        }
    }

    public class MostOrderedProducts
    {
        public static void Main(string[] args)
        {
            List<Order> orders = new List<Order>
        {
            new Order("Laptop", 10),
            new Order("Mouse", 50),
            new Order("Keyboard", 30),
            new Order("Laptop", 5),
            new Order("Headphones", 20),
            new Order("Mouse", 25),
            new Order("Keyboard", 15),
            new Order("Laptop", 15),
            new Order("Mouse", 30)
        };

            // 1. Get the top 3 most ordered products.
            var productQuantities = orders
                .GroupBy(o => o.ProductName)
                .Select(group => new
                {
                    ProductName = group.Key,
                    TotalQuantity = group.Sum(o => o.QuantityOrdered)
                })
                .OrderByDescending(p => p.TotalQuantity)
                .Take(3);

            // 2. Display them in descending order of quantity.
            Console.WriteLine("Top 3 most ordered products:");
            foreach (var product in productQuantities)
            {
                Console.WriteLine($"Product: {product.ProductName}, Total Quantity: {product.TotalQuantity}");
            }

            Console.ReadKey();
        }
    }
}
