using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_03_OOP
{
    internal class Faculty
    {
        int id;
        string name = string.Empty;
        int age;
        double weight;
        double height;

        public void GetFacultyDetails()
        {

            Console.WriteLine("Enter Faculty Id :");
            id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Faculty Name : ");
            name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter Faculty Age : ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Faculty Weight : ");
            weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Faculty Height : ");
            height = Convert.ToDouble(Console.ReadLine());

        }

        public void DisplayFacultyDetails()
        {
            Console.WriteLine("\nFacluty Detail :");
            Console.WriteLine("ID : " + id);
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Age : " + age);
            Console.WriteLine("Weight : " + weight);
            Console.WriteLine("Height : " + height);
        }
    }
}
