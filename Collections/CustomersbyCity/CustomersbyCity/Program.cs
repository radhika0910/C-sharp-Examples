using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersbyCity
{
   
    public class Customer
    {
        public string CustomerName { get; set; }
        public string City { get; set; }

        public Customer(string customerName, string city)
        {
            CustomerName = customerName;
            City = city;
        }

        public override string ToString()
        {
            return $"Customer: {CustomerName}, City: {City}";
        }
    }

    public class CustomersByCity
    {
        public static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
        {
            new Customer("Alice", "New York"),
            new Customer("Bob", "London"),
            new Customer("Charlie", "New York"),
            new Customer("David", "Paris"),
            new Customer("Eve", "London"),
            new Customer("Frank", "New York"),
            new Customer("Grace", "Paris"),
            new Customer("Henry", "Tokyo"),
            new Customer("Ivy", "London")
        };

            // 1. Group customers based on their City.
            var customersByCity = customers.GroupBy(c => c.City);

            // 2. Display the city along with the number of customers in that city.
            Console.WriteLine("Customers grouped by city:");
            foreach (var group in customersByCity)
            {
                Console.WriteLine($"City: {group.Key}, Number of Customers: {group.Count()}");
            }

            Console.ReadKey();
        }
    }
}
