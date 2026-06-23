using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    internal class DiagnosticScanner : MedicalEquipment
    {
        private double CalibrationAllowance;

        public DiagnosticScanner(string equipmentName, double serviceFee, double calibrationAllowance)
            : base(equipmentName, serviceFee)
        {
            CalibrationAllowance = calibrationAllowance;
        }

        public override double CalculateMaintenanceCost()
        {
            return ServiceFee + CalibrationAllowance;
        }

        public void Display()
        {
            Console.WriteLine("Equipment Name : " + EquipmentName);
            Console.WriteLine("Service Fee    : " + ServiceFee);
            Console.WriteLine("Calibration Allowance : " + CalibrationAllowance);
            Console.WriteLine("Maintenance Cost : " + CalculateMaintenanceCost());
        }
    }
}
