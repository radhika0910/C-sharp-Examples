using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionExamples
{
    using System;

   
    public class MyClass
    {
        public void Test1()
        {
            Console.WriteLine("Test1 method called.");
        }

        public void Test2()
        {
            Console.WriteLine("Test2 method called.");
        }
    }

    
    public static class MyClassExtensions
    {
        public static void Test2(this MyClass myObject) 
        {
            Console.WriteLine("Test3 extension method called.");
        }

        public static int Test4(this MyClass myObject, int value)
        {
            Console.WriteLine($"Test4 extension method called with value: {value}");
            return value * 2;
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            MyClass myInstance = new MyClass();

            
            myInstance.Test1();
            myInstance.Test2();

           
            //myInstance.Test3();

            int result = myInstance.Test4(5);
            Console.WriteLine($"Result from Test4: {result}");

            MyClass nullInstance = null;


            //if (nullInstance != null)
            //{
            //    //nullInstance.Test3();
            //}
            //else
            //{
            //    Console.WriteLine("nullInstance was null, so Test3 was not called");
            //}
        }
    }
}
