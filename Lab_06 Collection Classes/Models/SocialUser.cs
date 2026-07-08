using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_06_Collection_Classes.Models
{
    internal class SocialUser
    {
        public string Name { get; set; }
        public HashSet<string> Friends { get; set; }
        public HashSet<string> Interests { get; set; }

        public SocialUser(string name)
        {
            Name = name;
            Friends = new HashSet<string>();
            Interests = new HashSet<string>();
        }

    }
}
