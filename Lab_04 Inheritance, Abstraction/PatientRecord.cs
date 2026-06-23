using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    abstract class PatientRecord
    {
        public string PatientName;
        public PatientRecord(string patientName)
        {
            PatientName = patientName;
        }

        public abstract void CompileReport();
    }
}
