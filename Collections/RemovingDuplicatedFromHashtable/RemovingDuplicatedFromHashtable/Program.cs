using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemovingDuplicatedFromHashtable
{
    
    public class RemoveDuplicateIPs
    {
        public static void Main(string[] args)
        {
            Hashtable logData = new Hashtable
        {
            { 1, new LogEntry("192.168.1.1", DateTime.Now.AddMinutes(-10)) },
            { 2, new LogEntry("192.168.1.2", DateTime.Now.AddMinutes(-8)) },
            { 3, new LogEntry("192.168.1.1", DateTime.Now.AddMinutes(-5)) },
            { 4, new LogEntry("192.168.1.3", DateTime.Now.AddMinutes(-3)) },
            { 5, new LogEntry("192.168.1.2", DateTime.Now.AddMinutes(-1)) }
        };

            // 1. Remove duplicate IP addresses.
            var uniqueIPs = logData.Values
                .Cast<LogEntry>()
                .Select(entry => entry.IPAddress)
                .Distinct();

            // 2. Display the unique list of IP addresses.
            Console.WriteLine("Unique IP addresses:");
            foreach (var ip in uniqueIPs)
            {
                Console.WriteLine(ip);
            }

            Console.ReadKey();
        }

        public class LogEntry
        {
            public string IPAddress { get; set; }
            public DateTime Timestamp { get; set; }

            public LogEntry(string ipAddress, DateTime timestamp)
            {
                IPAddress = ipAddress;
                Timestamp = timestamp;
            }

            public override string ToString()
            {
                return $"IP: {IPAddress}, Timestamp: {Timestamp}";
            }
        }
    }
}
