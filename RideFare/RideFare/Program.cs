using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideFare
{

    public class RideFareCalculator
    {
        // Regular Ride Calculation
        public double CalculateFare(double distance, double baseFare, double perMileRate)
        {
            return baseFare + (distance * perMileRate);
        }

        // Premium Ride Calculation with Multiplier
        public double CalculateFare(double distance, double baseFare, double perMileRate, double premiumMultiplier)
        {
            double regularFare = CalculateFare(distance, baseFare, perMileRate);
            return regularFare * premiumMultiplier;
        }

        // Shared Ride Calculation with Multiple Passengers
        public double CalculateFare(double distance, double baseFare, double perMileRate, int numberOfPassengers, double sharedRideDiscount)
        {
            double regularFare = CalculateFare(distance, baseFare, perMileRate);
            double totalFare = regularFare;

            if (numberOfPassengers > 1)
            {
                double discountPerPassenger = sharedRideDiscount / numberOfPassengers;
                totalFare -= discountPerPassenger * numberOfPassengers;
            }

            return totalFare;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            RideFareCalculator calculator = new RideFareCalculator();

            // Regular Ride
            double regularFare = calculator.CalculateFare(10, 25.0, 15.0); 
            Console.WriteLine($"Regular Ride Fare: {regularFare}");

            // Premium Ride
            double premiumFare = calculator.CalculateFare(10, 25.0, 15.0, 1.8); // 1.8x multiplier
            Console.WriteLine($"Premium Ride Fare: {premiumFare}");

            // Shared Ride
            double sharedFare = calculator.CalculateFare(10, 25.0, 15.0, 3, 20.0); // 3 passengers, 20 rs discount
            Console.WriteLine($"Shared Ride Fare: {sharedFare}");
        }
    }
}
