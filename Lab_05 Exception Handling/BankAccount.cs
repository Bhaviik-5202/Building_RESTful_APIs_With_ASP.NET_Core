using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_05_Exception_Handling
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

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
                throw new InsufficientBalanceException("Insufficient Balance: requested amount exceeds current balance.");
            }

            balance -= amount;
            Console.WriteLine("Withdrawal Successful");
            Console.WriteLine("Available Balance: " + balance);
        }
    }
}
