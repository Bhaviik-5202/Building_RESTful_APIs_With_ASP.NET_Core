using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    internal class MedicalEquipment
    {
        public string EquipmentName;
        public double ServiceFee;

        public MedicalEquipment(string equipmentName, double serviceFee)
        {
            EquipmentName = equipmentName;
            ServiceFee = serviceFee;
        }

        public virtual double CalculateMaintenanceCost()
        {
            return ServiceFee;
        }
    }
}
