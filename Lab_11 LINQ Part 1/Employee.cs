using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_11_LINQ_Part_1
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }
        public List<string> Skills { get; set; }
    }
}
