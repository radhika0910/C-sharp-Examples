using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExamples
{  interface Example1
    {
         void display();

    }

    interface Example2
    {
        void display();
        void testing();
    }

    class deriverd : Example1 , Example2
    {
        void Example2.display()
        {
            Console.WriteLine(" This is Example1 ");

        }
        void Example2.testing()
        {
            Console.WriteLine(" This is Testing ");
        }

        void Example1.display()
        {
            Console.WriteLine(" This is  ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
