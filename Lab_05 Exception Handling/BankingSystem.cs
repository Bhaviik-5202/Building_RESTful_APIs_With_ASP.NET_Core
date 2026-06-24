using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_05_Exception_Handling
{
    interface ITransaction
    {
        void Deposit(double amount);
        void Withdraw(double amount);
    }
    public class BankingSystem : ITransaction
    {
        double balance;
        public BankingSystem(double initialBalance)
        {
            balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine("Deposit Amount : " + amount);
            Console.WriteLine("Current Balance : " + balance);
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new Exception("Insufficient Balance!\n");
            }
            balance -= amount;
            Console.WriteLine("Withdrawn Amount: " + amount);
            Console.WriteLine("Current Balance: " + balance);
        }
    }
}
