namespace Lab_02_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Lab 02: Loops, Strings & Arrays in C# ===");
                Console.WriteLine("1. Task 1 - Change Case of a Character");
                Console.WriteLine("2. Task 2 - Toggle String Case (Upper <-> Lower)");
                Console.WriteLine("3. Task 3 - Validate String Contains Substring");
                Console.WriteLine("4. Task 4 - Find Second Largest Element in Array");
                Console.WriteLine("5. Task 5 - Simple Calculator (Switch & Else-If)");
                Console.WriteLine("6. Task 6 - Sum of Array Elements");
                Console.WriteLine("7. Task 7 - Count Odd and Even Numbers in Array");
                Console.WriteLine("8. Task 8 - Replace First & Last Occurrence of Character");
                Console.WriteLine("9. Task 9 - Menu-Driven Array Operations");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": Task1.Run(); break;
                    case "2": Task2.Run(); break;
                    case "3": Task3.Run(); break;
                    case "4": Task4.Run(); break;
                    case "5": Task5.Run(); break;
                    case "6": Task6.Run(); break;
                    case "7": Task7.Run(); break;
                    case "8": Task8.Run(); break;
                    case "9": ArrayToDo.Run(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice. Try again."); break;
                }
            }
        }
    }

    // 1. Write a program to change the case of entered character.
    public class Task1
    {
        public static void Run()
        {
            Console.Write("Enter Character : ");
            char ch = ReadChar();
            Console.WriteLine();

            if (char.IsUpper(ch))
            {
                Console.WriteLine($"Lowercase: {char.ToLower(ch)}");
            }
            else if (char.IsLower(ch))
            {
                Console.WriteLine($"Uppercase : {char.ToUpper(ch)}");
            }
            else
            {
                Console.WriteLine("Not an Alphabet.");
            }
        }

        public static char ReadChar()
        {
            if (Console.IsInputRedirected)
            {
                string? line = Console.ReadLine();
                return !string.IsNullOrEmpty(line) ? line[0] : '\0';
            }
            return Console.ReadKey().KeyChar;
        }
    }

    // 2. Write a program to Replace lower case characters to upper case and Vice-versa.
    public class Task2
    {
        public static void Run()
        {
            Console.Write("Enter String : ");
            string word = Console.ReadLine() ?? "";
            string s2 = "";

            foreach (char i in word)
            {
                if (char.IsUpper(i))
                {
                    s2 += char.ToLower(i);
                }
                else if (char.IsLower(i))
                {
                    s2 += char.ToUpper(i);
                }
                else
                {
                    s2 += i;
                }
            }

            Console.WriteLine("Toggle String : " + s2);
        }
    }

    // 3. Take 2 strings from the user, and validate 2nd string is contains by 1st or not.
    public class Task3
    {
        public static void Run()
        {
            Console.Write("Enter String1 : ");
            string s1 = Console.ReadLine() ?? "";

            Console.Write("Enter String2 : ");
            string s2 = Console.ReadLine() ?? "";

            if (s1.Contains(s2))
            {
                Console.WriteLine($"Result: '{s2}' IS contained in '{s1}'");
            }
            else
            {
                Console.WriteLine($"Result: '{s2}' is NOT contained in '{s1}'");
            }
        }
    }

    // 4. Find the second largest element from an array.
    public class Task4
    {
        public static void Run()
        {
            Console.Write("Enter Number Of Elements : ");
            if (!int.TryParse(Console.ReadLine(), out int size) || size < 2)
            {
                Console.WriteLine("Array must have at least 2 elements.");
                return;
            }

            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter Element {i + 1}: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            int largest = int.MinValue;
            int second = int.MinValue;
            foreach (int i in arr)
            {
                if (i > largest)
                {
                    second = largest;
                    largest = i;
                }
                else if (i > second && i != largest)
                {
                    second = i;
                }
            }

            if (second == int.MinValue)
            {
                Console.WriteLine("All elements are identical; no distinct second largest element.");
            }
            else
            {
                Console.WriteLine($"Second Largest : {second}");
            }
        }
    }

    // 5. Write a program to create a Simple Calculator for two numbers
    // (Addition, Multiplication, Subtraction, Division)[using elseif ladder & Switch Case]
    public class Task5
    {
        public static void Run()
        {
            Console.Write("Enter First Number : ");
            int n1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Operator (+, -, *, /): ");
            char op = Task1.ReadChar();
            Console.WriteLine();

            Console.Write("Enter Second Number : ");
            int n2 = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case '+':
                    Console.WriteLine($"Sum : {n1 + n2}");
                    break;
                case '-':
                    Console.WriteLine($"Difference : {n1 - n2}");
                    break;
                case '*':
                    Console.WriteLine($"Product : {n1 * n2}");
                    break;
                case '/':
                    if (n2 == 0)
                        Console.WriteLine("Division by zero is not allowed.");
                    else
                        Console.WriteLine($"Quotient : {(double)n1 / n2}");
                    break;
                default:
                    Console.WriteLine("Enter Valid Operator.");
                    break;
            }
        }
    }

    // 6. Find the sum of all elements in an array.
    public class Task6
    {
        public static void Run()
        {
            Console.Write("Enter Number Of Elements : ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[size];
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter Element {i + 1}: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
                sum += arr[i];
            }

            Console.WriteLine("Sum Of All Elements = " + sum);
        }
    }

    // 7. Count odd and even numbers in an array.
    public class Task7
    {
        public static void Run()
        {
            Console.Write("Enter Number Of Elements : ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter Element {i + 1}: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            int oddCount = 0;
            int evenCount = 0;

            for (int i = 0; i < size; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            Console.WriteLine($"Total Odd Count : {oddCount}");
            Console.WriteLine($"Total Even Count : {evenCount}");
        }
    }

    // 8. Write a program which find out the first and last occurrence of a character
    // and then replace that character with ‘D’.
    public class Task8
    {
        public static void Run()
        {
            Console.Write("Enter a String: ");
            string str = Console.ReadLine() ?? "";

            Console.Write("Enter Character To Find: ");
            char ch = Task1.ReadChar();
            Console.WriteLine();

            int first = str.IndexOf(ch);
            int last = str.LastIndexOf(ch);

            if (first == -1)
            {
                Console.WriteLine($"Character '{ch}' not found in '{str}'.");
                return;
            }

            char[] arr = str.ToCharArray();
            arr[first] = 'D';
            arr[last] = 'D';

            string result = new string(arr);

            Console.WriteLine("First Position : " + first);
            Console.WriteLine("Last Position  : " + last);
            Console.WriteLine("Modified String: " + result);
        }
    }

    // 9. Menu-Driven Array Operations
    public class ArrayToDo
    {
        public static void Run()
        {
            int[] arr = Array.Empty<int>();

            while (true)
            {
                Console.WriteLine("\n--- ARRAY Menu-Driven ---");
                Console.WriteLine("1. Input Array");
                Console.WriteLine("2. Display Sum");
                Console.WriteLine("3. Count Odd and Even");
                Console.WriteLine("4. Find Second Largest");
                Console.WriteLine("5. Return to Main Menu");
                Console.Write("Enter Your Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid Choice!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Size of Array: ");
                        int size = Convert.ToInt32(Console.ReadLine());
                        arr = new int[size];
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write($"Enter Element {i + 1}: ");
                            arr[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        break;

                    case 2:
                        int sum = 0;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            sum += arr[i];
                        }
                        Console.WriteLine("Sum = " + sum);
                        break;

                    case 3:
                        int odd = 0, even = 0;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (arr[i] % 2 == 0) even++;
                            else odd++;
                        }
                        Console.WriteLine("Even Count = " + even);
                        Console.WriteLine("Odd Count = " + odd);
                        break;

                    case 4:
                        if (arr.Length < 2)
                        {
                            Console.WriteLine("Array needs at least 2 elements.");
                            break;
                        }
                        int largest = int.MinValue;
                        int second = int.MinValue;
                        foreach (int i in arr)
                        {
                            if (i > largest)
                            {
                                second = largest;
                                largest = i;
                            }
                            else if (i > second && i != largest)
                            {
                                second = i;
                            }
                        }
                        Console.WriteLine($"Second Largest : {second}");
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }
    }
}
