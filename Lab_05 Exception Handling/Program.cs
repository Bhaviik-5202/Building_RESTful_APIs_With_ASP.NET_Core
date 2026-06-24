using System.Security.Principal;

namespace Lab_05_Exception_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            /* 1. Write a program to perform division of two numbers entered by the user.
                  Use exception handling to catch and display an appropriate message 
                  when the denominator is zero.
            */
            try
            {
                Console.WriteLine("Enter Number 1 : ");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Number 2 : ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                int ans = num1 / num2;

                Console.WriteLine("Ans : " + ans);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error : Denominator cannot be zero.");
            }
            finally
            {
                Console.WriteLine("Program End.");
            }


            /* 2..Write a program to accept a numeric value from the user. 
             * Use exception handling to detect and 
             * handle invalid input when non-numeric data is entered.
             */
            try
            {
                Console.WriteLine("Enter Number : ");
                int num = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Your Number : " + num);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e);
            }
            finally
            {
                Console.WriteLine("Program End.");
            }


            /* 3. Write a program to create a BankAccount class with account number and balance. 
             * Use exception handling to display an error message 
             * when the withdrawal amount exceeds the available balance.
             */
            try
            {
                Console.Write("Enter Withdrawal Amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                BankAccount ac = new BankAccount(1001, 50000);
                ac.Withdraw(amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Program End.");
            }


            /* 4. Write a program to create a Student class with student details and marks. 
             * Use exception handling to generate an error 
             * when marks entered are less than 0 or greater than 100.
             */
            try
            {
                Console.Write("Enter Roll No: ");
                int rollNo = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Marks: ");
                int marks = Convert.ToInt32(Console.ReadLine());

                Student s = new Student(rollNo, name, marks);
                s.Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Program End.");
            }


            /* 5. Write a program to create a base class Employee and a derived class Manager. 
             * Use a custom exception to handle cases where the salary entered is negative.
             */
            try
            {
                Console.Write("Enter Employee ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Salary: ");
                double salary = Convert.ToDouble(Console.ReadLine());

                Manager m = new Manager(id, name, salary);
                m.Display();
            }
            catch (NegativeSalaryException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            /* 6. Write a program to create a base class Vehicle and a derived class Car. 
             * Use exception handling to display an error message 
             * when the speed entered exceeds the permitted limit.
             */
            try
            {
                Console.Write("Enter Speed: ");
                int speed = Convert.ToInt32(Console.ReadLine());

                Car c = new Car(speed);
                c.Display();
            }
            catch (OverSpeed ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            /* 7. Write a program to create an interface ITransaction with methods for deposit and withdrawal. 
             * Implement the interface in a class and use exception handling 
             * to manage invalid withdrawal transactions.
             */
            BankingSystem account = new BankingSystem(5000);
            try
            {
                account.Deposit(2000);
                account.Withdraw(3000);
                account.Withdraw(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }


            /* 8. Write a program to create an interface IPayment with a method to process payments. 
             * Implement the interface in different payment classes and 
             * use exception handling to handle invalid payment amounts or transaction failures.
             */
            try
            {
                IPayment p1 = new CreditCardPayment();
                p1.ProcessPayment(2000);

                IPayment p2 = new UPIPayment();
                p2.ProcessPayment(60000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
    }
}