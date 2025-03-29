using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigProj
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = ConfigurationManager.AppSettings["Sourc"];
            string username = ConfigurationManager.AppSettings["Username"];
            string password = ConfigurationManager.AppSettings["Password"];
            Console.WriteLine(filepath);
            Console.WriteLine(username);
            Console.WriteLine(password);
        }
    }
}
