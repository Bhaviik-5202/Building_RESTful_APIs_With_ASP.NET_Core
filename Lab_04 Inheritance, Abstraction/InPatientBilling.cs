using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    internal class InPatientBilling : Billing
    {
        public override void Print()
        {
            Console.WriteLine("This is InPatientBilling.");
        }
    }
}
