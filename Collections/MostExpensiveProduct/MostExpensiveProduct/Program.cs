using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostExpensiveProduct
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MostExpensiveProduct
    {
        public static void Main(string[] args)
        {
            Dictionary<string, decimal> products = new Dictionary<string, decimal>
        {
            { "Laptop", 1200.00m },
            { "Mouse", 25.50m },
            { "Keyboard", 80.00m },
            { "Headphones", 150.00m },
            { "Monitor", 350.00m },
            { "Printer", 200.00m }
        };

            // 1. Find the most expensive product.
            var mostExpensive = products.OrderByDescending(p => p.Value).FirstOrDefault();

            // 2. Display its name and price.
            if (mostExpensive.Key != null)
            {
                Console.WriteLine($"Most Expensive Product:");
                Console.WriteLine($"Name: {mostExpensive.Key}, Price: {mostExpensive.Value:C}");
            }
            else
            {
                Console.WriteLine("No products found.");
            }

            Console.ReadKey();
        }
    }
}
