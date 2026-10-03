namespace Lab_05_Exception_Handling
{
    class InvalidMarks : Exception
    {
        public InvalidMarks(string message)
            : base(message)
        {
        }
    }

    internal class Student
    {
         int rollNo;
         string name;
         int marks;

        public Student(int rollNo, string name, int marks)
        {
            this.rollNo = rollNo;
            this.name = name;

            if (marks < 0 || marks > 100)
            {
                throw new InvalidMarks("Marks must be between 0 and 100.");
            }

            this.marks = marks;
        }

        public void Display()
        {
            Console.WriteLine("Roll No: " + rollNo);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Marks: " + marks);
        }
    }
}