using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    internal class Doctor : Staff
    {
        private double DoctorAllowance;

        public Doctor(string name, double basicPay, double doctorAllowance)
            : base(name, basicPay) // Calls Staff constructor
        {
            DoctorAllowance = doctorAllowance;
        }
        public override double CalculateSalary()
        {
            return BasicPay + DoctorAllowance;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Doctor Allowance: " + DoctorAllowance);
            Console.WriteLine("Total Salary: " + CalculateSalary());
        }
    }
}
