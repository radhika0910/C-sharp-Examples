using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandeling
{    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
        public CustomException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class Class1
    {
        public void Method1()
        {
            Console.WriteLine("Class1.Method1() called.");
            try
            {
                Class2 obj2 = new Class2();
                obj2.Method2();
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Class1 caught a CustomException: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Class1 caught a general exception: {ex.Message}");
                throw;
            }
        }
    }

    public class Class2
    {
        public void Method2()
        {
            Console.WriteLine("Class2.Method2() called.");
            try
            {
                Class3 obj3 = new Class3();
                obj3.Method3();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Class2 caught an InvalidOperationException: {ex.Message}");
                throw new CustomException("Custom Exception from Class2", ex); // Wrap the original exception
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Class2 caught a general exception: {ex.Message}");
                throw;
            }
        }
    }

    public class Class3
    {
        public void Method3()
        {
            Console.WriteLine("Class3.Method3() called.");
           
            throw new InvalidOperationException("Simulated error in Class3.Method3().");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Class1 obj1 = new Class1();
            try
            {
                obj1.Method1();
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Program caught a CustomException: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Program caught an InvalidOperationException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Program caught a general exception: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}

