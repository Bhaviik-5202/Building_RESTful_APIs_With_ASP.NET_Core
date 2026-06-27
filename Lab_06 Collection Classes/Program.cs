namespace Lab_06_Collection_Classes
{
    internal class Program
    {
        //static List<Student> stu = new List<Student>();
        //static List<Cart> cart = new List<Cart>();
        static Dictionary<int, StudentDU> students = new Dictionary<int, StudentDU>();
        static void Main(string[] args)
        {
            /* 1. Develop a menu-driven console application to manage student records using List. 
             * Implement Add, Display, Search, Update, and Delete functionalities.
             */
            //int choice = 0;
            //do
            //{
            //    Console.WriteLine("1. Add Student");
            //    Console.WriteLine("2. Display Students");
            //    Console.WriteLine("3. Search Student");
            //    Console.WriteLine("4. Update Student");
            //    Console.WriteLine("5. Delete Student");
            //    Console.WriteLine("6. Exit");
            //    Console.Write("Enter Your Choice: ");
            //    choice = Convert.ToInt32(Console.ReadLine());

            //    switch (choice)
            //    {
            //        case 1:
            //            AddStudent();
            //            break;
            //        case 2:
            //            DisplayStudent();
            //            break;
            //        case 3:
            //            SearchStudent();
            //            break;
            //        case 4:
            //            UpdateStudent();
            //            break;
            //        case 5:
            //            DeleteStudent();
            //            break;
            //        case 6:
            //            Console.WriteLine("Exit.");
            //            return;
            //        default:
            //            Console.WriteLine("Plese, Enter Valid Choise");
            //            break;
            //    }
            //} while (choice != 6);

            /* 2. Implement a Shopping Cart system using List that supports adding items, removing items, viewing cart details, 
             * and calculating the total amount with a discount.
             */
            //int choice = 0;
            //do
            //{
            //    Console.WriteLine("\nSHOPPING CART");
            //    Console.WriteLine("1. Add Item");
            //    Console.WriteLine("2. Remove Item");
            //    Console.WriteLine("3. View Cart");
            //    Console.WriteLine("4. Search Item");
            //    Console.WriteLine("5. Calculate Total");
            //    Console.WriteLine("6. Exit");
            //    Console.Write("Enter Your Choice: ");
            //    choice = Convert.ToInt32(Console.ReadLine());

            //    switch (choice)
            //    {
            //        case 1:
            //            AddItem();
            //            break;
            //        case 2:
            //            RemoveItem();
            //            break;
            //        case 3:
            //            DisplayCart();
            //            break;
            //        case 4:
            //            SearchItem();
            //            break;
            //        case 5:
            //            CalculateTotal();
            //            break;
            //        case 6:
            //            Console.WriteLine("Thank You. (Exit)");
            //            return;
            //        default:
            //            Console.WriteLine("Plese, Enter Valid Choise");
            //            break;
            //    }
            //} while (choice != 6);


            /* 3. Create a Student Grade Book using Dictionary<int, Student> 
             * where each student record contains subject-wise marks. 
             * Implement features to add/update student details, calculate percentages, and display reports.
             */
            int choice = 0;
            do
            {
                Console.WriteLine("\nSTUDENT GRADE BOOK");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Display All Students");
                Console.WriteLine("5. Display Report");
                Console.WriteLine("6. Exit");
                Console.Write("Enter Choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        UpdateStudent();
                        break;
                    case 3:
                        SearchStudent();
                        break;
                    case 4:
                        DisplayStudents();
                        break;
                    case 5:
                        DisplayReport();
                        break;
                    case 6:
                        Console.WriteLine("Thank You!");
                        return;
                    default:
                        Console.WriteLine("Please, Enter Valid Choice.");
                        break;
                }
            } while (choice != 6);

        }
        //static void AddStudent()
        //{
        //    Console.WriteLine("Enter Student Id : ");
        //    int id = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Enter Student Name : ");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Enter Student Age :");
        //    int age = Convert.ToInt32(Console.ReadLine());
        //    stu.Add(new Student(id, name, age));

        //    Console.WriteLine("Student Add Successfully");
        //}

        //static void DisplayStudent()
        //{
        //    if (stu.Count == 0)
        //    {
        //        Console.WriteLine("Student List Empty.");
        //    }
        //    foreach (var student in stu)
        //    {
        //        Console.WriteLine($"ID: {student.id}, Name: {student.name}, Age: {student.age}");
        //    }
        //}

        //static void SearchStudent()
        //{
        //    Console.WriteLine("Enter Student Id To Search : ");
        //    int id = Convert.ToInt32(Console.ReadLine());
        //    var student = stu.Find(s => s.id == id);
        //    if (student != null)
        //    {
        //        Console.WriteLine($"ID: {student.id}, Name: {student.name}, Age: {student.age}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Student Not Found.");
        //    }
        //}

        //static void UpdateStudent()
        //{
        //    Console.Write("Enter Student ID to Update: ");
        //    int id = Convert.ToInt32(Console.ReadLine());
        //    var student = stu.Find(s => s.id == id);
        //    if (student != null)
        //    {
        //        Console.Write("Enter New Name: ");
        //        student.name = Console.ReadLine();
        //        Console.Write("Enter New Age: ");
        //        student.age = Convert.ToInt32(Console.ReadLine());
        //        Console.WriteLine("Student Updated Successfully.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Student not found.");
        //    }
        //}

        //static void DeleteStudent()
        //{
        //    Console.Write("Enter Student ID to Delete: ");
        //    int id = Convert.ToInt32(Console.ReadLine());
        //    var student = stu.Find(s => s.id == id);
        //    if (student != null)
        //    {
        //        stu.Remove(student);
        //        Console.WriteLine("Student Deleted Successfully.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Student not found.");
        //    }
        //}

        //static void AddItem()
        //{
        //    Cart c = new Cart();

        //    Console.Write("Enter Id: ");
        //    c.Id = Convert.ToInt32(Console.ReadLine());

        //    Console.Write("Enter Item Name: ");
        //    c.ItemName = Console.ReadLine();

        //    Console.Write("Enter Price: ");
        //    c.Price = Convert.ToDouble(Console.ReadLine());

        //    Console.Write("Enter Quantity: ");
        //    c.Quantity = Convert.ToInt32(Console.ReadLine());

        //    Console.Write("Enter Rating (1-5): ");
        //    c.Rating = Convert.ToInt32(Console.ReadLine());

        //    cart.Add(c);

        //    Console.WriteLine("Item Added Successfully.");
        //}
        //static void RemoveItem()
        //{
        //    Console.Write("Enter Item Id to Remove: ");
        //    int id = Convert.ToInt32(Console.ReadLine());

        //    foreach (Cart c in cart)
        //    {
        //        if (c.Id == id)
        //        {
        //            cart.Remove(c);
        //            Console.WriteLine("Item Removed Successfully.");
        //            return;
        //        }
        //    }
        //    Console.WriteLine("Item Not Found.");
        //}

        //static void DisplayCart()
        //{
        //    if (cart.Count == 0)
        //    {
        //        Console.WriteLine("Cart is Empty.");
        //        return;
        //    }

        //    Console.WriteLine("ID\tName\tPrice\tQty\tRating\tAmount");
        //    foreach (Cart c in cart)
        //    {
        //        Console.WriteLine($"{c.Id}\t{c.ItemName}\t{c.Price}\t{c.Quantity}\t{c.Rating}\t{c.Price * c.Quantity}");
        //    }
        //}


        //static void SearchItem()
        //{
        //    Console.Write("Enter Item Id: ");
        //    int id = Convert.ToInt32(Console.ReadLine());

        //    foreach (Cart c in cart)
        //    {
        //        if (c.Id == id)
        //        {
        //            Console.WriteLine("\nItem Found");
        //            Console.WriteLine("ID       : " + c.Id);
        //            Console.WriteLine("Name     : " + c.ItemName);
        //            Console.WriteLine("Price    : " + c.Price);
        //            Console.WriteLine("Quantity : " + c.Quantity);
        //            Console.WriteLine("Rating   : " + c.Rating);
        //            return;
        //        }
        //    }
        //    Console.WriteLine("Item Not Found.");
        //}
        //static void CalculateTotal()
        //{
        //    double total = 0;
        //    foreach (Cart c in cart)
        //    {
        //        total += c.Price * c.Quantity;
        //    }
        //    Console.WriteLine("\nTotal Amount : " + total);

        //    double discount = 0;
        //    if (total >= 5000)
        //        discount = total * 0.20;
        //    else if (total >= 3000)
        //        discount = total * 0.15;
        //    else if (total >= 1000)
        //        discount = total * 0.10;

        //    Console.WriteLine("Discount : " + discount);
        //    Console.WriteLine("Final Amount : " + (total - discount));
        //}

        static void AddStudent()
        {
            Console.Write("Enter Student ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (students.ContainsKey(id))
            {
                Console.WriteLine("Student ID already exists!");
                return;
            }
            Console.Write("Enter Student Name : ");
            string Name = Console.ReadLine();
            Console.Write("Enter CPP Marks : ");
            int CPP = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Applitude Marks : ");
            int Applitude = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter SQL Marks : ");
            int SQL = Convert.ToInt32(Console.ReadLine());

            students.Add(id, new StudentDU(id, Name, CPP, Applitude, SQL));
            Console.WriteLine("Student Added Successfully.");
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (students.ContainsKey(id))
            {
                Console.Write("Enter New CPP Marks: ");
                students[id].CPP = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter New Applitude Marks: ");
                students[id].Applitude = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter New SQL Marks: ");
                students[id].SQL = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Marks Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Student Not Found!");
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter Student ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (students.ContainsKey(id))
            {
                StudentDU s = students[id];

                Console.WriteLine("\nID : " + s.Id);
                Console.WriteLine("Name : " + s.Name);
                Console.WriteLine("CPP : " + s.CPP);
                Console.WriteLine("Applitude : " + s.Applitude);
                Console.WriteLine("SQL : " + s.SQL);
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }
        }

        static void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Records Found.");
                return;
            }

            Console.WriteLine("=============================================================");
            Console.WriteLine("ID\tName\tCPP\tApplitude\tSQL");
            foreach (var student in students.Values)
            {
                Console.WriteLine($"{student.Id}\t{student.Name}\t{student.SQL}\t{student.Applitude}\t\t{student.SQL}");
                //Console.WriteLine($"{s.Id}\t{s.Name}\t{total}\t{percentage:F2}%");
            }
        }

        static void DisplayReport()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Records Found.");
                return;
            }

            Console.WriteLine("==============================");
            Console.WriteLine("ID\tName\tTotal\tPercentage");

            foreach (KeyValuePair<int, StudentDU> item in students)
            {
                StudentDU s = item.Value;

                int total = s.CPP + s.Applitude + s.SQL;
                double percentage = total / 3.0;

                Console.WriteLine($"{s.Id}\t{s.Name}\t{total}\t{percentage:F2}%");
            }
        }
    }
}
