using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeDevice
{
   

    abstract class SmartDevice
    {
        public abstract void TurnOn();
        public abstract void TurnOn(int duration);
    }

    class SmartLight : SmartDevice
    {
        public override void TurnOn()
        {
            Console.WriteLine("Smart Light is turned on.");
        }

        public override void TurnOn(int duration)
        {
            Console.WriteLine($"Smart Light is turned on for {duration} seconds.");
            Thread.Sleep(duration * 1000);
            Console.WriteLine("Smart Light is turned off.");
        }
    }

    class SmartAC : SmartDevice
    {
        public override void TurnOn()
        {
            Console.WriteLine("Smart AC is turned on.");
        }

        public override void TurnOn(int duration)
        {
            Console.WriteLine($"Smart AC is running for {duration} seconds.");
            Thread.Sleep(duration * 1000);
            Console.WriteLine("Smart AC is turned off.");
        }
    }

    class SmartTV : SmartDevice
    {
        public override void TurnOn()
        {
            Console.WriteLine("Smart TV is turned on.");
        }

        public override void TurnOn(int duration)
        {
            Console.WriteLine($"Smart TV is playing for {duration} seconds.");
            Thread.Sleep(duration * 1000);
            Console.WriteLine("Smart TV is turned off.");
        }
    }

    class Program
    {
        static void Main()
        {
            SmartDevice light = new SmartLight();
            SmartDevice ac = new SmartAC();
            SmartDevice tv = new SmartTV();

            light.TurnOn();
            light.TurnOn(5);

            ac.TurnOn();
            ac.TurnOn(3);

            tv.TurnOn();
            tv.TurnOn(4);
        }
    }

}
