using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempMonitor
{
    using System;

    public delegate void TemperatureExceededHandler(int temperature);

    public class TemperatureSensor
    {
        public event TemperatureExceededHandler TemperatureExceeded;

        public void CheckTemperature(int temp)
        {
            if (temp > 40)
            {
                if (TemperatureExceeded != null)
                {
                    TemperatureExceeded(temp);
                }
            }
        }
    }

    public class TemperatureMonitor
    {
        public static void Main(string[] args)
        {
            TemperatureSensor sensor = new TemperatureSensor();

            sensor.TemperatureExceeded += Sensor_TemperatureExceeded;

            sensor.CheckTemperature(35);
            sensor.CheckTemperature(42);
            sensor.CheckTemperature(38);
            sensor.CheckTemperature(45);
            sensor.CheckTemperature(20);

            Console.ReadKey();
        }

        private static void Sensor_TemperatureExceeded(int temperature)
        {
            Console.WriteLine($"WARNING: Temperature exceeded 40°C. Current temperature: {temperature}°C");
        }
    }
}
