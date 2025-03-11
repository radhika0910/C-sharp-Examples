using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedClass
{

    class Printer
    {
        internal void print()
        {
            Console.WriteLine("5X5");
        }

        virtual internal void Display()
        {
            Console.WriteLine("5 x 5");
        }
    }

    class LaserJet : Printer
    {
        sealed override internal void Display()
        {
            Console.WriteLine("10 x 10");
        }

    }


    abstract class Loan
    {
        internal abstract void eligible();
    }

    class LoanRequest : Loan
    {
        internal override void eligible()
        {
            Console.WriteLine("Yes U get loan");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            LoanRequest obj = new LoanRequest();
            obj.eligible();
        }
    }
}
