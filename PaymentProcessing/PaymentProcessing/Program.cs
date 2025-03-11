using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing
{

    //class Payment
    //{
    //   internal void ProcessPayment()
    //    {

    //    }

    //    internal void ProcessPayment(bool status)
    //    {
    //        Console.WriteLine($"The pRocess complete : {status}");
    //    }
    //}

    abstract class Payment
    {
        internal  abstract void ProcessPayment();
    }

    internal class CreditCard : Payment
    {
        internal override void ProcessPayment()
        {
            Console.WriteLine("Done Through Credit Card");

        }


    }

    class BankTransfer : Payment
    {
        internal override void ProcessPayment()
        {
            Console.WriteLine("Done Through Bank Transfer");
           
        }
    }

    class PayPal : Payment
    {
        internal override void ProcessPayment()
        {
            Console.WriteLine("Done Through Pay Pal");
            
        }
    }

   

    class Program
    {
        static void Main(string[] args)
        {
            CreditCard c1 = new CreditCard();
            PayPal p1 = new PayPal();
            BankTransfer b1 = new BankTransfer();
           c1.ProcessPayment();
           
            Console.WriteLine("\n");
           b1.ProcessPayment();
           
            Console.WriteLine("\n");

            p1.ProcessPayment();
            
            Console.WriteLine("\n");

        }
    }
}
