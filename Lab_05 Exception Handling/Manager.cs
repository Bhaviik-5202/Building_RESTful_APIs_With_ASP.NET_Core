using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_05_Exception_Handling
{
    internal class Manager : Employee
    {
        public Manager(int empId, string name, double salary)
        : base(empId, name, salary)
        {
        }

        public void Display()
        {
            Console.WriteLine("Employee ID: " + empId);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Salary: " + salary);
        }
       
    }
}
