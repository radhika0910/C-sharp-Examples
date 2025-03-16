using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
   
    public delegate int CalculatorOperation(int x, int y);

    public class SimpleCalculator
    {
        
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Subtract(int x, int y)
        {
            return x - y;
        }

        public static int Multiply(int x, int y)
        {
            return x * y;
        }

        public static int Divide(int x, int y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return x / y;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator");

            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose operation:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");

            Console.Write("Enter operation number: ");
            int operation = int.Parse(Console.ReadLine());

            CalculatorOperation calcOperation = null;

            switch (operation)
            {
                case 1:
                    calcOperation = Add;
                    break;
                case 2:
                    calcOperation = Subtract;
                    break;
                case 3:
                    calcOperation = Multiply;
                    break;
                case 4:
                    calcOperation = Divide;
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    return;
            }

            try
            {
                int result = calcOperation(num1, num2);
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
