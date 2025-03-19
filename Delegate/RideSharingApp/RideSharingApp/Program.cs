using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharingApp
{
    using System;
    using System.Threading;

    class RideSharingApp
    {
        static void FetchDriverLocation()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"📍 Fetching Driver Location... Update {i}");
                Thread.Sleep(1000); 
            }
            Console.WriteLine("✅ Driver location updated.");
        }

        static void ProcessPayment()
        {
            Console.WriteLine("💳 Processing Payment...");
            Thread.Sleep(3000); 
            Console.WriteLine("✅ Payment Successful!");
        }

        static void UpdateTripStatus()
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"🚗 Trip Status: In Progress ({i})");
                Thread.Sleep(2000);
            }
            Console.WriteLine("✅ Trip Completed.");
        }

        static void Main()
        {
            Console.WriteLine("🚀 Ride-Sharing App Started...");

           
            Thread locationThread = new Thread(FetchDriverLocation);
            Thread paymentThread = new Thread(ProcessPayment);
            Thread tripThread = new Thread(UpdateTripStatus);

            
            locationThread.Start();
            paymentThread.Start();
            tripThread.Start();

            
            locationThread.Join();
            paymentThread.Join();
            tripThread.Join();

            Console.WriteLine("🎉 Ride Completed Successfully!");
        }
    }

}
