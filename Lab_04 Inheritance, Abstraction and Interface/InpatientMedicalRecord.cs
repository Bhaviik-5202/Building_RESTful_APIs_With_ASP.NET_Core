using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    internal class InpatientMedicalRecord : PatientRecord
    {
        public int DaysAdmitted;

        public InpatientMedicalRecord(string patientName, int daysAdmitted)
            : base(patientName)
        {
            DaysAdmitted = daysAdmitted;
        }

        public override void CompileReport()
        {
            Console.WriteLine("\nInpatient Medical Record");
            Console.WriteLine("Patient Name : " + PatientName);
            Console.WriteLine("Days Admitted : " + DaysAdmitted);
        }
    }
}
