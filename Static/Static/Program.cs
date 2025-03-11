using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    using System;

    public abstract class MyAbstractClass
    {
        private MyAbstractClass()
        {
            
            Console.WriteLine("Private constructor called.");
            
        }

        public static MyAbstractClass CreateInstance() => MyAbstractClass.CreateInstance();

        public abstract void DoSomething();
    }

    //public class MyConcreteClass : MyAbstractClass
    //{
    //    public override void DoSomething()
    //    {
    //        Console.WriteLine("Doing something in MyConcreteClass.");
    //    }
    //}

    public class Program
    {
        public static void Main(string[] args)
        {
            MyAbstractClass instance = MyAbstractClass.CreateInstance();
            instance.DoSomething();

            Console.ReadKey();

        }
    }
}
