using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    internal class Staff
    {
        protected string Name;
        protected double BasicPay;

        public Staff(string name, double basicPay)
        {
            Name = name;
            BasicPay = basicPay;
        }

        public virtual double CalculateSalary()
        {
            return BasicPay;
        }

        public virtual void Display()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Basic Pay: " + BasicPay);
        }
    }
}
