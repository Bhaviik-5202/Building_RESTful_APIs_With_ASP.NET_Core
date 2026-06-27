using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_06_Collection_Classes
{
    internal class StudentDU
    {
        public int Id;
        public string Name;
        public int CPP;
        public int Applitude;
        public int SQL;

        public StudentDU(int Id, string Name, int CPP, int Applitude, int SQL)
        {
            this.Id = Id;
            this.Name = Name;
            this.CPP = CPP;
            this.Applitude = Applitude;
            this.SQL = SQL;
        }
    }
}
