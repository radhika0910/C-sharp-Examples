using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantOrdering
{
    

    class Order
    {
        public virtual void PlaceOrder()
        {
            Console.WriteLine("Order has been placed.");
        }

        public void PlaceOrder(string customerName)
        {
            Console.WriteLine($"Order for {customerName} has been placed.");
        }

        public void PlaceOrder(string customerName, int tableNumber)
        {
            Console.WriteLine($"Dine-in order for {customerName} at table {tableNumber} has been placed.");
        }
    }

    class DineInOrder : Order
    {
        public override void PlaceOrder()
        {
            Console.WriteLine("Dine-in order has been placed.");
        }
    }

    class TakeawayOrder : Order
    {
        public override void PlaceOrder()
        {
            Console.WriteLine("Takeaway order has been placed.");
        }
    }

    class OnlineOrder : Order
    {
        public override void PlaceOrder()
        {
            Console.WriteLine("Online order has been placed.");
        }
    }

    class Program
    {
        static void Main()
        {
            Order dineIn = new DineInOrder();
            Order takeaway = new TakeawayOrder();
            Order online = new OnlineOrder();

            dineIn.PlaceOrder();
            dineIn.PlaceOrder("John", 5);

            takeaway.PlaceOrder();
            takeaway.PlaceOrder("Alice");

            online.PlaceOrder();
        }
    }

}
