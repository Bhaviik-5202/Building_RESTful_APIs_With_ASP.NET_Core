using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_05_Exception_Handling
{
    internal class UPIPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid Payment Amount!");
            }
            if (amount > 5000)
            {
                throw new Exception("Transaction Failed: UPI Limit Exceeded!");
            }

            Console.WriteLine("UPI Payment Successful: " + amount);
        }
    }
}
