using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotDevice
{

    // Define the IDevice interface
    public interface IDevice
    {
        void Connect();
        void SendData(string data);
        string ReceiveData();
        string DeviceId { get; } // Add a DeviceId property
    }

    // TemperatureSensor implementation
    public class TemperatureSensor : IDevice
    {
        public string DeviceId { get; } = "TemperatureSensor-123"; // Example Device ID
        private bool isConnected = false;
        private double currentTemperature = 25.0; // Simulate temperature data

        public void Connect()
        {
            Console.WriteLine($"{DeviceId}: Connecting...");
            isConnected = true;
            Console.WriteLine($"{DeviceId}: Connected.");
        }

        public void SendData(string data)
        {
            if (isConnected)
            {
                Console.WriteLine($"{DeviceId}: Sending data: {data}");
            }
            else
            {
                Console.WriteLine($"{DeviceId}: Not connected. Cannot send data.");
            }
        }

        public string ReceiveData()
        {
            if (isConnected)
            {
                // Simulate receiving temperature data
                currentTemperature += new Random().NextDouble() - 0.5; // Simulate temperature change
                return $"Temperature: {currentTemperature:F2} °C";
            }
            else
            {
                return $"{DeviceId}: Not connected. Cannot receive data.";
            }
        }
    }

    // MotionSensor implementation
    public class MotionSensor : IDevice
    {
        public string DeviceId { get; } = "MotionSensor-456"; // Example Device ID
        private bool isConnected = false;
        private bool motionDetected = false; // Simulate motion detection

        public void Connect()
        {
            Console.WriteLine($"{DeviceId}: Connecting...");
            isConnected = true;
            Console.WriteLine($"{DeviceId}: Connected.");
        }

        public void SendData(string data)
        {
            if (isConnected)
            {
                Console.WriteLine($"{DeviceId}: Sending data: {data}");
            }
            else
            {
                Console.WriteLine($"{DeviceId}: Not connected. Cannot send data.");
            }
        }

        public string ReceiveData()
        {
            if (isConnected)
            {
                // Simulate motion detection
                motionDetected = new Random().Next(0, 2) == 1; // Randomly detect motion
                return $"Motion Detected: {motionDetected}";
            }
            else
            {
                return $"{DeviceId}: Not connected. Cannot receive data.";
            }
        }
    }

    // Example usage
    public class Program
    {
        public static void Main(string[] args)
        {
            IDevice temperatureSensor = new TemperatureSensor();
            IDevice motionSensor = new MotionSensor();

            temperatureSensor.Connect();
            motionSensor.Connect();

            temperatureSensor.SendData("Requesting temperature data.");
            Console.WriteLine(temperatureSensor.ReceiveData());

            motionSensor.SendData("Requesting motion status.");
            Console.WriteLine(motionSensor.ReceiveData());

            temperatureSensor.SendData("Sending a test message");
            motionSensor.SendData("Sending a test message");

            Console.ReadKey();
        }
    }
}
