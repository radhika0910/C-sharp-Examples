using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverloadingandRiding
{

    public interface IFlightBookingDetails
    {
        string PassengerName { get; }
        string Destination { get; }
    }

    public class BasicBookingDetails : IFlightBookingDetails
    {
        public string PassengerName { get; }
        public string Destination { get; }

        public BasicBookingDetails(string passengerName, string destination)
        {
            PassengerName = passengerName;
            Destination = destination;
        }
    }

    // Concrete implementation for booking details with class type
    public class ClassBookingDetails : IFlightBookingDetails
    {
        public string PassengerName { get; }
        public string Destination { get; }
        public string ClassType { get; }

        public ClassBookingDetails(string passengerName, string destination, string classType)
        {
            PassengerName = passengerName;
            Destination = destination;
            ClassType = classType;
        }
    }

    // Concrete implementation for booking details with multiple passengers
    public class MultiPassengerBookingDetails : IFlightBookingDetails
    {
        public string PassengerName { get; } //represents the primary passenger name.
        public string Destination { get; }
        public List<string> PassengerNames { get; }

        public MultiPassengerBookingDetails(string primaryPassengerName, string destination, List<string> passengerNames)
        {
            PassengerName = primaryPassengerName;
            Destination = destination;
            PassengerNames = passengerNames;
        }
    }

    // Interface for flight booking operations
    public interface IFlightBookingService
    {
        void BookTicket(BasicBookingDetails details);
        void BookTicket(ClassBookingDetails details);
        void BookTicket(MultiPassengerBookingDetails details);
    }

    // Concrete implementation of flight booking service
    public class FlightBookingService : IFlightBookingService
    {
        public void BookTicket(BasicBookingDetails details)
        {
            Console.WriteLine($"Booking ticket for {details.PassengerName} to {details.Destination}.");
            // Logic to book a basic ticket
        }

        public void BookTicket(ClassBookingDetails details)
        {
            Console.WriteLine($"Booking ticket for {details.PassengerName} to {details.Destination} in {details.ClassType} class.");
            // Logic to book a ticket with class type
        }

        public void BookTicket(MultiPassengerBookingDetails details)
        {
            Console.WriteLine($"Booking ticket for {details.PassengerName} and {details.PassengerNames.Count} additional passengers to {details.Destination}.");
            // Logic to book tickets for multiple passengers
            Console.WriteLine("Passengers: ");
            foreach (string passenger in details.PassengerNames)
            {
                Console.WriteLine($"- {passenger}");
            }
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IFlightBookingService bookingService = new FlightBookingService();

            BasicBookingDetails basicBooking = new BasicBookingDetails("Ram", "New York");
            bookingService.BookTicket(basicBooking);

            ClassBookingDetails classBooking = new ClassBookingDetails("Bob", "London", "Business");
            bookingService.BookTicket(classBooking);

            MultiPassengerBookingDetails multiPassengerBooking = new MultiPassengerBookingDetails("Charlie", "Tokyo", new List<string> { "David", "Eve" });
            bookingService.BookTicket(multiPassengerBooking);
        }
    }
}
