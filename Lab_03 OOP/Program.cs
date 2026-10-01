
namespace Lab_03_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*1.Write a program to create a class named Faculty with ID, Name, Age, Weight and Height
                as data members & also create a member function
                like GetFacultyDetails() and DisplayFacultyDetails().
            */
            Faculty fc = new Faculty();
            fc.GetFacultyDetails();
            fc.DisplayFacultyDetails();


            /* 2. Write a program to create a class named Employee 
             *    with Emp_ID, Name, Department, Designation and Salary 
             *    as data members & also create a member function 
             *    like GetEmpDetails() and DisplayEmpDetails() for five different employee objects. 
             */
            Employee[] em = new Employee[5];
            for (int i = 0; i < 5; i++)
            {
                em[i] = new Employee();

                Console.WriteLine("\nEmployee " + (i + 1));
                em[i].GetEmpDetails();
            }
            Console.WriteLine("\nEmployee Detail :");
            for (int i = 0; i < 5; i++)
            {
                em[i].DisplayEmpDetails();
            }


            /* 3. Write a program to calculate Volume of a Cube using constructor. */
            Console.Write("Enter the side of the cube: ");
            double side = Convert.ToDouble(Console.ReadLine());

            Cube c = new Cube(side);
            c.DisplayVolume();


            /* 4. A car dealership wants to display details of premium sports cars. 
             *    Create a Car object with Make, Model, Year, FuelType and Horsepower details 
             *    (use constructor).
             */
            Console.WriteLine("Enter Make : ");
            string Make = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter Model : ");
            string Model = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter Year : ");
            int Year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter FuelType : ");
            string FuelType = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter HorsePower : ");
            double HorsePower = Convert.ToDouble(Console.ReadLine());

            PremiumCar pr = new PremiumCar(Make, Model, Year, FuelType, HorsePower);
            pr.DisplayDetails();


            /* 5. Write a program to manage a supermarket inventory. 
             * Create an Item class with Item_Code, Item_Name, and Stock_Quantity. 
             * Use a constructor to initialize the objects and 
             * an array of objects to store and display the details of 10 different items.
             */
            Item[] sp = new Item[10];
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter Details for Item {i + 1}");

                Console.Write("Enter Item Code: ");
                int code = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Item Name: ");
                string name = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Stock Quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                sp[i] = new Item(code, name, quantity);
            }

            Console.WriteLine("\nInventory Detail");
            for (int i = 0; i < 10; i++)
            {
                sp[i].DisplayInventory();
            }

            /* 6.  A clinic management system needs to store patient records. 
             *     Create a program with a Patient class 
             *     containing Patient_ID, Name, Age, and Disease. 
             *     Use an array of objects to accept details for multiple patients and 
             *     display a formatted summary report of all patients. 
             */
            Console.Write("Enter Number Of Patients: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Patient[] p = new Patient[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter Details of Patient {i + 1}");

                Console.Write("Patient ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine() ?? string.Empty;

                Console.Write("Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Disease: ");
                string disease = Console.ReadLine() ?? string.Empty;

                p[i] = new Patient(id, name, age, disease);
            }

            Console.WriteLine("\nPATIENT SUMMARY REPORT\n");
            Console.WriteLine($"{"Patient ID",-12}{"Name",-20}{"Age",-10}{"Disease",-20}");
            Console.WriteLine(new string('-', 62));

            for (int i = 0; i < n; i++)
            {
                p[i].DisplayDetails();
            }

        }
    }
}
