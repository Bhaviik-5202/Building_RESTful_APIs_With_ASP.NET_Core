using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_03_OOP
{
    internal class Employee
    {
        public int id;
        public string name = string.Empty;
        public string department = string.Empty;
        public string designation = string.Empty;
        public double salary;

        public void GetEmpDetails()
        {
            Console.WriteLine("Enter Employee Id :");
            id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employee Name :");
            name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter Employee Department :");
            department = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter Employee Designation :");
            designation = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter Employee Salary :");
            salary = Convert.ToDouble(Console.ReadLine());
        }

        public void DisplayEmpDetails()
        {
            Console.WriteLine("\n Employee Detail :");
            Console.WriteLine("ID : " + id);
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Department : " + department);
            Console.WriteLine("Designation : " + designation);
            Console.WriteLine("Salary : " + salary);
        }
    }
}
