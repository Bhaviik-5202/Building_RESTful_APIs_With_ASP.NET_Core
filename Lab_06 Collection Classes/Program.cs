namespace Lab_06_Collection_Classes
{
    internal class Program
    {
        static List<Student> stu = new List<Student>();
        static void Main(string[] args)
        {
            /* 1. Develop a menu-driven console application to manage student records using List. 
             * Implement Add, Display, Search, Update, and Delete functionalities.
             */
            int choice = 0;
            do
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");
                Console.Write("Enter Your Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DisplayStudent();
                        break;
                    case 3:
                        SearchStudent();
                        break;
                    case 4:
                        UpdateStudent();
                        break;
                    case 5:
                        DeleteStudent();
                        break;
                    case 6:
                        Console.WriteLine("Exit.");
                        return;
                    default:
                        Console.WriteLine("Plese, Enter Valid Choise");
                        break;
                }
            } while (choice != 6);
        }
        static void AddStudent()
        {
            Console.WriteLine("Enter Student Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student Age :");
            int age = Convert.ToInt32(Console.ReadLine());
            stu.Add(new Student(id, name, age));

            Console.WriteLine("Student Add Successfully");
        }

        static void DisplayStudent()
        {
            if (stu.Count == 0)
            {
                Console.WriteLine("Student List Empty.");
            }
            foreach (var student in stu)
            {
                Console.WriteLine($"ID: {student.id}, Name: {student.name}, Age: {student.age}");
            }
        }

        static void SearchStudent()
        {
            Console.WriteLine("Enter Student Id To Search : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var student = stu.Find(s => s.id == id);
            if (student != null)
            {
                Console.WriteLine($"ID: {student.id}, Name: {student.name}, Age: {student.age}");
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student ID to Update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var student = stu.Find(s => s.id == id);
            if (student != null)
            {
                Console.Write("Enter New Name: ");
                student.name = Console.ReadLine();
                Console.Write("Enter New Age: ");
                student.age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Student Updated Successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student ID to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var student = stu.Find(s => s.id == id);
            if (student != null)
            {
                stu.Remove(student);
                Console.WriteLine("Student Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
