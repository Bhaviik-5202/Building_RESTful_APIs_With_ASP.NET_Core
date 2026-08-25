namespace Lab_11_LINQ_Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var sampleData = new[]
            {
                new { Name = "Amit", Branch = "CE", Sem = 3, CPI = 8.5, ExtraValue = (object)"Topper", Courses = new List<string>() { "C#", "DBMS" } },
                new { Name = "Neha", Branch = "IT", Sem = 4, CPI = 9.1, ExtraValue = (object)100, Courses = new List<string>() { "Java", "AI" } },
                new { Name = "Raj", Branch = "CE", Sem = 3, CPI = 7.8, ExtraValue = (object)"Sports", Courses = new List<string>() { "C#", "Math" } },
                new { Name = "Priya", Branch = "IT", Sem = 5, CPI = 8.9, ExtraValue = (object)200, Courses = new List<string>() { "Python", "DBMS" } },
                new { Name = "Kiran", Branch = "ME", Sem = 2, CPI = 7.2, ExtraValue = (object)"Workshop", Courses = new List<string>() { "CAD", "Physics" } },
                new { Name = "Pooja", Branch = "CE", Sem = 4, CPI = 8.3, ExtraValue = (object)150, Courses = new List<string>() { "C#", "Data Structures" } },
                new { Name = "Rahul", Branch = "EC", Sem = 6, CPI = 7.9, ExtraValue = (object)"Robotics", Courses = new List<string>() { "Signals", "IoT" } },
                new { Name = "Sneha", Branch = "IT", Sem = 3, CPI = 8.7, ExtraValue = (object)"Hackathon", Courses = new List<string>() { "Python", "Web" } },
                new { Name = "Vivek", Branch = "CE", Sem = 5, CPI = 6.9, ExtraValue = (object)75, Courses = new List<string>() { "JavaScript", "DBMS" } },
                new { Name = "Anjali", Branch = "ME", Sem = 4, CPI = 8.1, ExtraValue = (object)"Design", Courses = new List<string>() { "CAD", "Thermodynamics" } },
                new { Name = "Manish", Branch = "EC", Sem = 2, CPI = 7.5, ExtraValue = (object)120, Courses = new List<string>() { "Electronics", "Math" } },
                new { Name = "Riya", Branch = "CE", Sem = 6, CPI = 9.3, ExtraValue = (object)"Research", Courses = new List<string>() { "C#", "AI" } },
                new { Name = "Harsh", Branch = "IT", Sem = 5, CPI = 7.4, ExtraValue = (object)"NSS", Courses = new List<string>() { "Java", "Networking" } },
                new { Name = "Meera", Branch = "CE", Sem = 2, CPI = 8.0, ExtraValue = (object)180, Courses = new List<string>() { "C#", "Physics" } },
                new { Name = "Sahil", Branch = "ME", Sem = 6, CPI = 6.8, ExtraValue = (object)"Sports", Courses = new List<string>() { "Mechanics", "CAD" } },
                new { Name = "Nisha", Branch = "EC", Sem = 4, CPI = 8.6, ExtraValue = (object)90, Courses = new List<string>() { "IoT", "Signals" } },
                new { Name = "Arjun", Branch = "IT", Sem = 2, CPI = 7.7, ExtraValue = (object)"Coding", Courses = new List<string>() { "Python", "DBMS" } },
                new { Name = "Divya", Branch = "CE", Sem = 5, CPI = 8.8, ExtraValue = (object)250, Courses = new List<string>() { "C#", "Web" } },
                new { Name = "Yash", Branch = "EC", Sem = 3, CPI = 7.1, ExtraValue = (object)"Music", Courses = new List<string>() { "Electronics", "C" } },
                new { Name = "Kavya", Branch = "ME", Sem = 5, CPI = 8.4, ExtraValue = (object)300, Courses = new List<string>() { "Thermodynamics", "Math" } },
                new { Name = "Rohan", Branch = "CE", Sem = 4, CPI = 6.7, ExtraValue = (object)"Volunteer", Courses = new List<string>() { "Data Structures", "DBMS" } },
                new { Name = "Isha", Branch = "IT", Sem = 6, CPI = 9.0, ExtraValue = (object)"Topper", Courses = new List<string>() { "AI", "Python" } },
                new { Name = "Nikhil", Branch = "EC", Sem = 5, CPI = 7.6, ExtraValue = (object)60, Courses = new List<string>() { "Signals", "Networking" } },
                new { Name = "Tanya", Branch = "CE", Sem = 3, CPI = 8.2, ExtraValue = (object)"Seminar", Courses = new List<string>() { "C#", "Math" } },
                new { Name = "Om", Branch = "ME", Sem = 2, CPI = 7.0, ExtraValue = (object)110, Courses = new List<string>() { "Physics", "Mechanics" } },
                new { Name = "Bhavya", Branch = "IT", Sem = 4, CPI = 8.5, ExtraValue = (object)"Project", Courses = new List<string>() { "Java", "Web" } },
                new { Name = "Dev", Branch = "CE", Sem = 6, CPI = 9.2, ExtraValue = (object)400, Courses = new List<string>() { "AI", "DBMS" } },
                new { Name = "Jinal", Branch = "EC", Sem = 2, CPI = 7.3, ExtraValue = (object)"Club", Courses = new List<string>() { "C", "Electronics" } },
                new { Name = "Parth", Branch = "ME", Sem = 3, CPI = 8.1, ExtraValue = (object)210, Courses = new List<string>() { "CAD", "Math" } },
                new { Name = "Krisha", Branch = "IT", Sem = 5, CPI = 8.9, ExtraValue = (object)"Internship", Courses = new List<string>() { "Python", "Networking" } },
                new { Name = "Mihir", Branch = "CE", Sem = 2, CPI = 7.8, ExtraValue = (object)95, Courses = new List<string>() { "C#", "Physics" } },
                new { Name = "Avni", Branch = "EC", Sem = 6, CPI = 8.0, ExtraValue = (object)"Robotics", Courses = new List<string>() { "IoT", "Signals" } },
                new { Name = "Het", Branch = "ME", Sem = 4, CPI = 6.6, ExtraValue = (object)"Workshop", Courses = new List<string>() { "Mechanics", "CAD" } },
                new { Name = "Esha", Branch = "IT", Sem = 3, CPI = 8.3, ExtraValue = (object)170, Courses = new List<string>() { "JavaScript", "DBMS" } },
                new { Name = "Jay", Branch = "CE", Sem = 5, CPI = 7.5, ExtraValue = (object)"Sports", Courses = new List<string>() { "C#", "Web" } },
                new { Name = "Mansi", Branch = "EC", Sem = 4, CPI = 9.1, ExtraValue = (object)500, Courses = new List<string>() { "AI", "Electronics" } },
                new { Name = "Darshan", Branch = "ME", Sem = 6, CPI = 7.9, ExtraValue = (object)"Design", Courses = new List<string>() { "Thermodynamics", "CAD" } },
                new { Name = "Aarohi", Branch = "CE", Sem = 4, CPI = 8.7, ExtraValue = (object)225, Courses = new List<string>() { "Data Structures", "C#" } },
                new { Name = "Smit", Branch = "IT", Sem = 2, CPI = 6.9, ExtraValue = (object)"Music", Courses = new List<string>() { "Java", "Math" } },
                new { Name = "Falguni", Branch = "EC", Sem = 5, CPI = 8.2, ExtraValue = (object)"Seminar", Courses = new List<string>() { "Signals", "IoT" } },
                new { Name = "Meet", Branch = "CE", Sem = 3, CPI = 7.4, ExtraValue = (object)130, Courses = new List<string>() { "DBMS", "Web" } },
                new { Name = "Charmi", Branch = "ME", Sem = 5, CPI = 8.6, ExtraValue = (object)"Project", Courses = new List<string>() { "CAD", "Mechanics" } },
                new { Name = "Hiren", Branch = "IT", Sem = 6, CPI = 7.8, ExtraValue = (object)85, Courses = new List<string>() { "Networking", "AI" } },
                new { Name = "Kinjal", Branch = "CE", Sem = 2, CPI = 9.0, ExtraValue = (object)"Topper", Courses = new List<string>() { "C#", "Physics" } },
                new { Name = "Varun", Branch = "EC", Sem = 3, CPI = 7.2, ExtraValue = (object)"NCC", Courses = new List<string>() { "Electronics", "Math" } },
                new { Name = "Pallavi", Branch = "ME", Sem = 4, CPI = 8.0, ExtraValue = (object)145, Courses = new List<string>() { "Thermodynamics", "Physics" } },
                new { Name = "Naitik", Branch = "IT", Sem = 5, CPI = 8.4, ExtraValue = (object)"Coding", Courses = new List<string>() { "Python", "Web" } },
                new { Name = "Shreya", Branch = "CE", Sem = 6, CPI = 9.4, ExtraValue = (object)550, Courses = new List<string>() { "AI", "C#" } },
                new { Name = "Rudra", Branch = "EC", Sem = 2, CPI = 6.8, ExtraValue = (object)"Sports", Courses = new List<string>() { "C", "Electronics" } },
                new { Name = "Aditi", Branch = "ME", Sem = 3, CPI = 7.7, ExtraValue = (object)"Workshop", Courses = new List<string>() { "CAD", "Math" } },
                new { Name = "Kartik", Branch = "CE", Sem = 5, CPI = 8.1, ExtraValue = (object)190, Courses = new List<string>() { "DBMS", "Data Structures" } },
                new { Name = "Jiya", Branch = "IT", Sem = 4, CPI = 9.2, ExtraValue = (object)"Research", Courses = new List<string>() { "AI", "Python" } },
                new { Name = "Pranav", Branch = "EC", Sem = 6, CPI = 7.5, ExtraValue = (object)105, Courses = new List<string>() { "Signals", "Networking" } },
                new { Name = "Simran", Branch = "ME", Sem = 2, CPI = 8.3, ExtraValue = (object)"Design", Courses = new List<string>() { "Mechanics", "Physics" } },
                new { Name = "Dhruv", Branch = "CE", Sem = 4, CPI = 7.0, ExtraValue = (object)"Club", Courses = new List<string>() { "C#", "Math" } },
                new { Name = "Riddhi", Branch = "IT", Sem = 3, CPI = 8.6, ExtraValue = (object)230, Courses = new List<string>() { "Java", "DBMS" } },
                new { Name = "Ankit", Branch = "EC", Sem = 5, CPI = 8.8, ExtraValue = (object)"Robotics", Courses = new List<string>() { "IoT", "AI" } },
                new { Name = "Payal", Branch = "ME", Sem = 6, CPI = 7.1, ExtraValue = (object)70, Courses = new List<string>() { "Thermodynamics", "CAD" } },
                new { Name = "Moksh", Branch = "CE", Sem = 2, CPI = 7.9, ExtraValue = (object)"Seminar", Courses = new List<string>() { "Web", "C#" } },
                new { Name = "Sakshi", Branch = "IT", Sem = 6, CPI = 8.5, ExtraValue = (object)"Internship", Courses = new List<string>() { "Networking", "Python" } }
            };

            List<Student> students = sampleData
                .Select((s, index) => new Student()
                {
                    Rno = index + 1,
                    Name = s.Name,
                    Branch = s.Branch,
                    Sem = s.Sem,
                    CPI = s.CPI,
                    ExtraValue = s.ExtraValue,
                    Courses = s.Courses
                })
                .ToList();

            // Task 1: Display the total number of students registered in the system.
            Console.WriteLine("Task 1: Display the total number of students registered in the system.");
            var totalStudents = students.Count();
            Console.WriteLine($"Total Students: {totalStudents}");
            Console.WriteLine();

            // Task 2: Display the total number of faculty members guiding projects.
            Console.WriteLine("Task 2: Display the total number of faculty members guiding projects.");
            var totalBranches = students
                .Select(s => s.Branch)
                .Distinct()
                .Count();
            Console.WriteLine($"Total Branches: {totalBranches}");
            Console.WriteLine();

            // Task 3: Display the total number of projects available in the system.
            Console.WriteLine("Task 3: Display the total number of projects available in the system.");
            var totalCourses = students
                .SelectMany(s => s.Courses)
                .Distinct()
                .Count();
            Console.WriteLine($"Total Courses: {totalCourses}");
            Console.WriteLine();

            // Task 4: Show how many tasks belong to each status category.
            Console.WriteLine("Task 4: Show how many tasks belong to each status category.");
            var statusCategory = students
                .GroupBy(s =>
                {
                    if (s.CPI >= 9) return "Excellent";
                    if (s.CPI >= 8) return "Good";
                    if (s.CPI >= 7) return "Average";
                    return "Poor";
                })
                .Select(g => new { Category = g.Key, TotalStudents = g.Count() })
                .OrderBy(x => x.Category);

            foreach (var item in statusCategory)
            {
                Console.WriteLine($"{item.Category} : {item.TotalStudents}");
            }
            Console.WriteLine();

            // Task 5: Show priority wise task count.
            Console.WriteLine("Task 5: Show priority wise task count.");
            var priorityWise = students
                .GroupBy(s =>
                {
                    if (s.CPI >= 9) return "High";
                    if (s.CPI >= 8) return "Medium";
                    return "Low";
                })
                .Select(g => new { Priority = g.Key, TotalStudents = g.Count() })
                .OrderByDescending(x => x.TotalStudents);

            foreach (var item in priorityWise)
            {
                Console.WriteLine($"{item.Priority} : {item.TotalStudents}");
            }
            Console.WriteLine();

            // Task 6: Show how many projects are assigned to each faculty member.
            Console.WriteLine("Task 6: Show how many projects are assigned to each faculty member.");
            var studentsByBranch = students
                .GroupBy(s => s.Branch)
                .Select(g => new { Branch = g.Key, TotalStudents = g.Count() });

            foreach (var item in studentsByBranch)
            {
                Console.WriteLine($"{item.Branch} : {item.TotalStudents}");
            }
            Console.WriteLine();

            // Task 7: Show how many tasks have been assigned to each student.
            Console.WriteLine("Task 7: Show how many tasks have been assigned to each student.");
            var coursesPerStudent = students
                .Select(s => new { s.Name, TotalCourses = s.Courses.Count });

            foreach (var item in coursesPerStudent)
            {
                Console.WriteLine($"{item.Name} : {item.TotalCourses}");
            }
            Console.WriteLine();

            // Task 8: Display top 10 students having highest average earned score.
            Console.WriteLine("Task 8: Display top 10 students having highest average earned score.");
            var top10Students = students
                .OrderByDescending(s => s.CPI)
                .Take(10)
                .Select((s, index) => new { Rank = index + 1, s.Name, s.CPI });

            foreach (var item in top10Students)
            {
                Console.WriteLine($"{item.Rank}. {item.Name} - CPI: {item.CPI}");
            }
            Console.WriteLine();

            // Task 9: Display bottom 10 students based on average earned score.
            Console.WriteLine("Task 9: Display bottom 10 students based on average earned score.");
            var bottom10Students = students
                .OrderBy(s => s.CPI)
                .Take(10)
                .Select((s, index) => new { Rank = index + 1, s.Name, s.CPI });

            foreach (var item in bottom10Students)
            {
                Console.WriteLine($"{item.Rank}. {item.Name} - CPI: {item.CPI}");
            }
            Console.WriteLine();

            // Task 10: Display all tasks whose due date has passed but are not completed.
            Console.WriteLine("Task 10: Display all tasks whose due date has passed but are not completed.");
            var lowCpiStudents = students
                .Where(s => s.CPI < 7)
                .Select(s => new { s.Name, s.Branch, s.Sem, s.CPI });

            foreach (var item in lowCpiStudents)
            {
                Console.WriteLine($"{item.Name} | {item.Branch} | Sem {item.Sem} | CPI {item.CPI}");
            }
            Console.WriteLine();

            // Task 11: Display tasks having follow-up dates within next 7 days.
            Console.WriteLine("Task 11: Display tasks having follow-up dates within next 7 days.");
            var latestSemester = students.Max(s => s.Sem);
            var latestSemesterStudents = students
                .Where(s => s.Sem == latestSemester)
                .Select(s => new { s.Name, s.Branch, s.Sem, s.CPI });

            foreach (var item in latestSemesterStudents)
            {
                Console.WriteLine($"{item.Name} | {item.Branch} | Sem {item.Sem} | CPI {item.CPI}");
            }
            Console.WriteLine();

            // Task 12: Show how many students have obtained each grade.
            Console.WriteLine("Task 12: Show how many students have obtained each grade.");
            var gradeWise = students
                .GroupBy(s =>
                {
                    if (s.CPI >= 9) return "A";
                    if (s.CPI >= 8) return "B";
                    if (s.CPI >= 7) return "C";
                    return "D";
                })
                .Select(g => new { Grade = g.Key, Students = g.Count() })
                .OrderBy(x => x.Grade);

            foreach (var item in gradeWise)
            {
                Console.WriteLine($"{item.Grade} : {item.Students}");
            }
            Console.WriteLine();

            // Task 13: Show month-wise completed task count.
            Console.WriteLine("Task 13: Show month-wise completed task count.");
            var semesterCount = students
                .GroupBy(s => s.Sem)
                .Select(g => new { Semester = g.Key, TotalStudents = g.Count() })
                .OrderBy(x => x.Semester);

            foreach (var item in semesterCount)
            {
                Console.WriteLine($"Semester {item.Semester} : {item.TotalStudents}");
            }
            Console.WriteLine();

            // Task 14: Display Role Wise Active User Count.
            Console.WriteLine("Task 14: Display Role Wise Active User Count.");
            var branchCount = students
                .GroupBy(s => s.Branch)
                .Select(g => new { Branch = g.Key, Students = g.Count() })
                .OrderByDescending(x => x.Students);

            foreach (var item in branchCount)
            {
                Console.WriteLine($"{item.Branch} : {item.Students}");
            }
            Console.WriteLine();

            // Task 15: Display each role with users assigned to it.
            Console.WriteLine("Task 15: Display each role with users assigned to it.");
            var usersByBranch = students
                .GroupBy(s => s.Branch)
                .Select(g => new { Branch = g.Key, Users = g.Select(s => s.Name).ToList() });

            foreach (var group in usersByBranch)
            {
                Console.WriteLine($"Branch: {group.Branch}");
                foreach (var name in group.Users)
                {
                    Console.WriteLine($"  {name}");
                }
            }
            Console.WriteLine();

            // Task 16: List roles having more than 10 users.
            Console.WriteLine("Task 16: List roles having more than 10 users.");
            var largeBranches = students
                .GroupBy(s => s.Branch)
                .Select(g => new { Branch = g.Key, TotalStudents = g.Count() })
                .Where(x => x.TotalStudents > 10);

            foreach (var item in largeBranches)
            {
                Console.WriteLine($"{item.Branch} : {item.TotalStudents}");
            }
            Console.WriteLine();

            // Task 17: Display role statistics.
            Console.WriteLine("Task 17: Display role statistics.");
            var branchStatistics = students
                .GroupBy(s => s.Branch)
                .Select(g => new
                {
                    Branch = g.Key,
                    TotalStudents = g.Count(),
                    HighCPIStudents = g.Count(s => s.CPI >= 8),
                    LowCPIStudents = g.Count(s => s.CPI < 8)
                });

            foreach (var item in branchStatistics)
            {
                Console.WriteLine($"{item.Branch} | Total: {item.TotalStudents} | CPI >= 8: {item.HighCPIStudents} | CPI < 8: {item.LowCPIStudents}");
            }
            Console.WriteLine();

            // Task 18: Show tasks due within next 7 days.
            Console.WriteLine("Task 18: Show tasks due within next 7 days.");
            var highCpiStudents = students
                .Where(s => s.CPI >= 9)
                .Select(s => new { s.Name, s.Branch, s.Sem, s.CPI })
                .OrderByDescending(s => s.CPI);

            foreach (var item in highCpiStudents)
            {
                Console.WriteLine($"{item.Name} | {item.Branch} | Sem {item.Sem} | CPI {item.CPI}");
            }
            Console.WriteLine();

            // Task 19: Display each project with total tasks, completed tasks, pending tasks, and average task progress.
            Console.WriteLine("Task 19: Display each project with total tasks, completed tasks, pending tasks, and average task progress.");
            var branchPerformance = students
                .GroupBy(s => s.Branch)
                .Select(g => new
                {
                    Branch = g.Key,
                    TotalStudents = g.Count(),
                    Completed = g.Count(s => s.CPI >= 8),
                    Pending = g.Count(s => s.CPI < 8),
                    AverageCPI = Math.Round(g.Average(s => s.CPI), 2)
                });

            foreach (var item in branchPerformance)
            {
                Console.WriteLine($"{item.Branch} | Total: {item.TotalStudents} | Good: {item.Completed} | Below 8: {item.Pending} | Avg CPI: {item.AverageCPI}");
            }
            Console.WriteLine();

            // Task 20: Display project-wise total assigned score, earned score and score percentage.
            Console.WriteLine("Task 20: Display project-wise total assigned score, earned score and score percentage.");
            var branchScore = students
                .GroupBy(s => s.Branch)
                .Select(g => new
                {
                    Branch = g.Key,
                    TotalStudents = g.Count(),
                    AverageCPI = Math.Round(g.Average(s => s.CPI), 2),
                    ScorePercentage = Math.Round((g.Average(s => s.CPI) / 10) * 100, 2)
                });

            foreach (var item in branchScore)
            {
                Console.WriteLine($"{item.Branch} | Students: {item.TotalStudents} | Avg CPI: {item.AverageCPI} | Percentage: {item.ScorePercentage}%");
            }
            Console.WriteLine();

            // Task 21: Display Top 10 projects based on average earned score.
            Console.WriteLine("Task 21: Display Top 10 projects based on average earned score.");
            var topBranches = students
                .GroupBy(s => s.Branch)
                .Select(g => new { Branch = g.Key, AverageCPI = g.Average(s => s.CPI) })
                .OrderByDescending(x => x.AverageCPI)
                .Take(10)
                .Select((x, index) => new { Rank = index + 1, x.Branch, AverageCPI = Math.Round(x.AverageCPI, 2) });

            foreach (var item in topBranches)
            {
                Console.WriteLine($"{item.Rank}. {item.Branch} - Avg CPI: {item.AverageCPI}");
            }
            Console.WriteLine();

            // Task 22: Show project count, task count and average progress for each faculty.
            Console.WriteLine("Task 22: Show project count, task count and average progress for each faculty.");
            var branchDetails = students
                .GroupBy(s => s.Branch)
                .Select(g => new
                {
                    Branch = g.Key,
                    TotalStudents = g.Count(),
                    TotalCourses = g.SelectMany(s => s.Courses).Distinct().Count(),
                    AverageCPI = Math.Round(g.Average(s => s.CPI), 2)
                });

            foreach (var item in branchDetails)
            {
                Console.WriteLine($"{item.Branch} | Students: {item.TotalStudents} | Courses: {item.TotalCourses} | Avg CPI: {item.AverageCPI}");
            }
            Console.WriteLine();

            // Task 23: Display task completion statistics and average score for each student.
            Console.WriteLine("Task 23: Display task completion statistics and average score for each student.");
            var studentStatistics = students
                .Select(s => new
                {
                    s.Name,
                    TotalCourses = s.Courses.Count,
                    CPI = s.CPI,
                    Status = s.CPI >= 8 ? "Good" : "Needs Improvement"
                });

            foreach (var item in studentStatistics)
            {
                Console.WriteLine($"{item.Name} | Courses: {item.TotalCourses} | CPI: {item.CPI} | {item.Status}");
            }
            Console.WriteLine();

            // Task 24: Display projects whose expected completion date has passed but are still incomplete.
            Console.WriteLine("Task 24: Display projects whose expected completion date has passed but are still incomplete.");
            var incompleteStudents = students
                .Where(s => s.CPI < 8)
                .OrderBy(s => s.CPI)
                .Select(s => new { s.Name, s.Branch, s.Sem, s.CPI });

            foreach (var item in incompleteStudents)
            {
                Console.WriteLine($"{item.Name} | {item.Branch} | Sem {item.Sem} | CPI {item.CPI}");
            }
            Console.WriteLine();

            // Task 25: Show month-wise completed task count.
            Console.WriteLine("Task 25: Show month-wise completed task count.");
            var semesterWise = students
                .GroupBy(s => s.Sem)
                .Select(g => new { Semester = g.Key, TotalStudents = g.Count() })
                .OrderBy(x => x.Semester);

            foreach (var item in semesterWise)
            {
                Console.WriteLine($"Semester {item.Semester} : {item.TotalStudents}");
            }
            Console.WriteLine();

            // Task 26: Rank faculties based on average project progress.
            Console.WriteLine("Task 26: Rank faculties based on average project progress.");
            var branchRanking = students
                .GroupBy(s => s.Branch)
                .Select(g => new { Branch = g.Key, AverageCPI = g.Average(s => s.CPI) })
                .OrderByDescending(x => x.AverageCPI)
                .Select((x, index) => new { Rank = index + 1, x.Branch, AverageCPI = Math.Round(x.AverageCPI, 2) });

            foreach (var item in branchRanking)
            {
                Console.WriteLine($"{item.Rank}. {item.Branch} - Avg CPI: {item.AverageCPI}");
            }
            Console.WriteLine();

            // Task 27: Display task statistics for every project.
            Console.WriteLine("Task 27: Display task statistics for every project.");
            var finalStatistics = students
                .GroupBy(s => s.Branch)
                .Select(g => new
                {
                    Branch = g.Key,
                    TotalStudents = g.Count(),
                    Excellent = g.Count(s => s.CPI >= 9),
                    Good = g.Count(s => s.CPI >= 8 && s.CPI < 9),
                    Average = g.Count(s => s.CPI >= 7 && s.CPI < 8),
                    Poor = g.Count(s => s.CPI < 7),
                    HighestCPI = g.Max(s => s.CPI),
                    LowestCPI = g.Min(s => s.CPI),
                    AverageCPI = Math.Round(g.Average(s => s.CPI), 2)
                })
                .OrderBy(x => x.Branch);

            foreach (var item in finalStatistics)
            {
                Console.WriteLine($"Branch: {item.Branch} | Total: {item.TotalStudents} | Excellent: {item.Excellent} | Good: {item.Good} | Average: {item.Average} | Poor: {item.Poor} | High CPI: {item.HighestCPI} | Low CPI: {item.LowestCPI} | Avg CPI: {item.AverageCPI}");
            }
            Console.WriteLine();

        }
    }

    public class Student
    {
        public int Rno { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public int Sem { get; set; }
        public double CPI { get; set; }
        public object? ExtraValue { get; set; }
        public List<string> Courses { get; set; } = new List<string>();
    }
}
