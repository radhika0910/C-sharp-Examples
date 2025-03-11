using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiSystem
{

    abstract class Notification
    {
        internal abstract void SendNotification();
    }

    class emailNotification : Notification
    {

        internal override void SendNotification()
        {
            Console.WriteLine("The email notification method");
        }

    }

    class smsNotification : Notification
    {
        internal override void SendNotification()
        {
            Console.WriteLine("The sms notification method");
        }

    }

    class pushNotifiaction : Notification
    {
        internal override void SendNotification()
        {
            Console.WriteLine("The sms notification method");
        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            pushNotifiaction p = new pushNotifiaction();
            smsNotification s = new smsNotification();
            emailNotification e = new emailNotification();


        }
    }
}
