using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_05_Exception_Handling
{
    interface IPayment
    {
        void ProcessPayment(double amount);
    }
    internal class CreditCardPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid Payment Amount!");
            }

            Console.WriteLine("Credit Card Payment Successful: " + amount);
        }
    }
}
