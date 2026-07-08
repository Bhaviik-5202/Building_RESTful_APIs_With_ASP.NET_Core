using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_06_Collection_Classes.Models
{
    internal class User
    {
        public string Name { get; set; }
        public List<string> Roles { get; set; }

        public User(string name)
        {
            Name = name;
            Roles = new List<string>();
        }
    }
}
