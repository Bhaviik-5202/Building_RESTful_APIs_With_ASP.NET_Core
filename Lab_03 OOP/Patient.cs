using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_03_OOP
{
    internal class Patient
    {
        private int Patient_ID;
        private string Name;
        private int Age;
        private string Disease;

        public Patient(int patientID, string name, int age, string disease)
        {
            Patient_ID = patientID;
            Name = name;
            Age = age;
            Disease = disease;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"{Patient_ID,-12}{Name,-20}{Age,-10}{Disease,-20}");
        }
    }
}
