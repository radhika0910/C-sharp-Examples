using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFactory
{



    using System;

    
    public interface IVehicle
    {
        void StartEngine();
        void StopEngine();
    }

   
    public class Car : IVehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("Car engine started.");
        }

        public void StopEngine()
        {
            Console.WriteLine("Car engine stopped.");
        }
    }

    public class Bike : IVehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("Bike engine started.");
        }

        public void StopEngine()
        {
            Console.WriteLine("Bike engine stopped.");
        }
    }

   
    public class VehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType)
        {
            switch (vehicleType.ToLower())
            {
                case "car":
                    return new Car();
                case "bike":
                    return new Bike();
                default:
                    throw new ArgumentException($"Invalid vehicle type: {vehicleType}");
            }
        }
    }

   
    public class Program
    {
        public static void Main(string[] args)
        {
            VehicleFactory factory = new VehicleFactory();
            string input;

            do
            {
                Console.WriteLine("Enter vehicle type (car or bike) or 'exit' to quit:");
                input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break; 
                }

                try
                {
                    IVehicle vehicle = factory.CreateVehicle(input);
                    vehicle.StartEngine();
                    vehicle.StopEngine();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (true); 

            Console.WriteLine("Program terminated.");
        }
    }
}
