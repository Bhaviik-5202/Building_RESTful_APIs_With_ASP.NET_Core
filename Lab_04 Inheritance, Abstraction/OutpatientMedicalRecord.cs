using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    internal class OutpatientMedicalRecord : PatientRecord
    {
        public string VisitDate;

        public OutpatientMedicalRecord(string patientName, string visitDate)
            : base(patientName)
        {
            VisitDate = visitDate;
        }

        public override void CompileReport()
        {
            Console.WriteLine("\nOutpatient Medical Record");
            Console.WriteLine("Patient Name : " + PatientName);
            Console.WriteLine("Visit Date : " + VisitDate);
        }
    }
}
