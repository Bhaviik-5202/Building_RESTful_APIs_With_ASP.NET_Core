using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_05_Exception_Handling
{
    class NegativeSalaryException : Exception
    {
        public NegativeSalaryException(string message) : base(message) { }
    }

    internal class Employee
    {
        public int empId;
        public string name;
        public double salary;

        public Employee(int empId, string name, double salary)
        {
            if (salary < 0)
            {
                throw new NegativeSalaryException("Salary cannot be negative.");
            }

            this.empId = empId;
            this.name = name;
            this.salary = salary;
        }
    }
}
