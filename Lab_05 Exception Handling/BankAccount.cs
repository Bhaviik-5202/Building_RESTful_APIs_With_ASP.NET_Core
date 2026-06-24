using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_05_Exception_Handling
{
    internal class BankAccount
    {
        private int accountNumber;
        private double balance;

        public BankAccount(int accNo, double bal)
        {
            accountNumber = accNo;
            balance = bal;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new Exception("Insufficient Balance");
            }

            balance -= amount;
            Console.WriteLine("Withdrawal Successful");
            Console.WriteLine("Available Balance: " + balance);
        }
    }
}
