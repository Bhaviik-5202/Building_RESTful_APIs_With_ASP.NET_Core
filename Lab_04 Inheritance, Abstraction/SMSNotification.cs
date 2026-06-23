using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    internal class SMSNotification : INotificationService
    {
        public void Print()
        {
            Console.WriteLine("This Is SMS Notification.");
        }
    }
}
