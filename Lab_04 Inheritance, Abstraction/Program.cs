using System.Numerics;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* 1. Create a base class Staff and a derived class Doctor to calculate total salary 
             *    based on a basic pay and specialized doctor allowances.
             */
            Console.WriteLine("Enter Doctor Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Basic Pay: ");
            double basicPay = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Doctor Allowance: ");
            double allowance = Convert.ToDouble(Console.ReadLine());

            Doctor d = new Doctor(name, basicPay, allowance);
            d.Display();



            /* 2. Create an abstract class Billing with an abstract method CalculateBill(). 
             * Implement this in InPatientBilling and OutPatientBilling classes.
             */
            InPatientBilling p1 = new InPatientBilling();
            OutPatientBilling p2 = new OutPatientBilling();

            p1.Print();
            p2.Print();



            /* 3. Create an interface INotificationService and 
             * implement it across an EmailNotification and SMSNotification module.
             */
            INotificationService i1 = new EmailNotification();
            INotificationService i2 = new SMSNotification();

            i1.Print();
            i2.Print();



            /* 4. Create a base class MedicalEquipment and a derived class DiagnosticScanner 
             *    to calculate maintenance costs based on a 
             *    baseline service fee and specialized calibration allowances.
             */
            Console.Write("Enter Equipment Name: ");
            string name2 = Console.ReadLine();

            Console.Write("Enter Service Fee: ");
            double fee = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Calibration Allowance: ");
            double allowance2 = Convert.ToDouble(Console.ReadLine());

            DiagnosticScanner ds = new DiagnosticScanner(name2, fee, allowance2);

            Console.WriteLine("\nEquipment Details");
            ds.Display();



            /* 5. Create an abstract class PatientRecord with an abstract method CompileReport(). 
             *    Implement this in InpatientMedicalRecord and OutpatientMedicalRecord classes.
             */
            InpatientMedicalRecord inpatient = new InpatientMedicalRecord("Ronak", 5);
            OutpatientMedicalRecord outpatient = new OutpatientMedicalRecord("Deep", "18-06-2026");

            inpatient.CompileReport();
            outpatient.CompileReport();


            /* 6. Create an interface IInventoryManager and implement 
             *    it across GroceryStock and ElectronicStock modules. 
             *    Use exception handling to manage stock shortages and incorrect product details.
             */
            try
            {
                GroceryStock g = new GroceryStock("Rice", 100);
                g.RemoveStock(20);
                g.Display();

                Console.WriteLine();

                ElectronicStock e = new ElectronicStock("Laptop", 10);
                e.RemoveStock(15);
                e.Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
    }
}
