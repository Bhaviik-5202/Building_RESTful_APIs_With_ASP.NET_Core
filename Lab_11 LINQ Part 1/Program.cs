namespace Lab_11_LINQ_Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var departments = new List<Department>
            {
                new Department { DeptId = 1, DeptName = "HR" },
                new Department { DeptId = 2, DeptName = "IT" },
                new Department { DeptId = 3, DeptName = "Finance" },
                new Department { DeptId = 4, DeptName = "Marketing" }
            };

            var employees = new List<Employee>
            {
                new Employee { Id = 101, Name = "Amit",   Age = 28, Salary = 75000, DeptId = 2, Skills = new List<string>{ "C#", "SQL", "Angular" } },
                new Employee { Id = 102, Name = "Neha",   Age = 34, Salary = 95000, DeptId = 2, Skills = new List<string>{ "Java", "C#", "React" } },
                new Employee { Id = 103, Name = "Raj",    Age = 45, Salary = 60000, DeptId = 1, Skills = new List<string>{ "Excel", "Communication" } },
                new Employee { Id = 104, Name = "Priya",  Age = 29, Salary = 82000, DeptId = 3, Skills = new List<string>{ "Accounting", "SQL" } },
                new Employee { Id = 105, Name = "Karan",  Age = 31, Salary = 88000, DeptId = 2, Skills = new List<string>{ "C#", "Azure", "Docker" } },
                new Employee { Id = 106, Name = "Simran", Age = 26, Salary = 72000, DeptId = 4, Skills = new List<string>{ "Design", "Photoshop" } },
                new Employee { Id = 107, Name = "Rohan",  Age = 38, Salary = 92000, DeptId = 5, Skills = new List<string>{ "Salesforce", "Communication", "Excel" } },
                new Employee { Id = 108, Name = "Sneha",  Age = 27, Salary = 68000, DeptId = 1, Skills = new List<string>{ "Recruitment", "Communication", "Excel" } },
                new Employee { Id = 109, Name = "Vikram", Age = 40, Salary = 98000, DeptId = 3, Skills = new List<string>{ "Accounting", "Power BI", "SQL" } },
                new Employee { Id = 110, Name = "Pooja",  Age = 30, Salary = 85000, DeptId = 4, Skills = new List<string>{ "Canva", "Photoshop", "Marketing" } }
            };

            //1. Display the names of all employees.
            var employeeNames = employees.Select(emp => emp.Name).ToList();
            foreach (var name in employeeNames)
            {
                Console.WriteLine("Employee Name: " + name);
            }
            Console.WriteLine("\n");


            //2.Display only employee IDs.
            var employeeIds = employees.Select(emp => emp.Id).ToList();
            foreach (var id in employeeIds)
            {
                Console.WriteLine("Employee ID: " + id);
            }
            Console.WriteLine("\n");

            // 3. Display Name and Salary.
            var employeeNameSalary = employees.Select(emp => new { emp.Name, emp.Salary }).ToList();
            foreach (var emp in employeeNameSalary)
            {
                Console.WriteLine($"Employee Name: {emp.Name}, Salary: {emp.Salary}");
            }
            Console.WriteLine("\n");


            // 4. Display Name and Age.
            var employeeNameAge = employees.Select(emp => new { emp.Name, emp.Age }).ToList();
            foreach (var emp in employeeNameAge)
            {
                Console.WriteLine($"Employee Name: {emp.Name}, Age: {emp.Age}");
            }
            Console.WriteLine("\n");


            // 5. Create an anonymous object containing Name and Department Id.
            var employeeNameDeptId = employees.Select(emp => new { emp.Name, emp.DeptId }).ToList();
            foreach (var emp in employeeNameDeptId)
            {
                Console.WriteLine($"Employee Name: {emp.Name}, Department Id: {emp.DeptId}");
            }
            Console.WriteLine("\n");


            // 6. Display employees older than 30 years.
            var employeesOlderThan30 = employees.Where(emp => emp.Age > 30).ToList();
            foreach (var emp in employeesOlderThan30)
            {
                Console.WriteLine($"Employee Name: {emp.Name}, Age: {emp.Age}");
            }
            Console.WriteLine("\n");


            // 7. Display employees whose salary is greater than ₹80,000.
            var employeesSalary = employees.Where(emp => emp.Salary > 80000).ToList();

            foreach (var emp in employeesSalary)
            {
                Console.WriteLine($"Employee Name: {emp.Name}, Salary: {emp.Salary}");
            }
            Console.WriteLine("\n");


            // 8. Display employees belonging to the IT department.
            var empITDept = employees.Join(
                departments,
                emp => emp.DeptId,
                dept => dept.DeptId,
                (emp, dept) => new { emp.Name, DeptName = dept.DeptName })
                .Where(result => result.DeptName == "IT")
                .ToList();
            foreach (var emp in empITDept)
            {
                Console.WriteLine($"Name: {emp.Name}, Department: {emp.DeptName}");
            }


            // 9. Display employees belonging to the Finance department.
            var empFinanceDept = employees.Join(
                departments,
                emp => emp.DeptId,
                dept => dept.DeptId,
                (emp, dept) => new { emp.Name, DeptName = dept.DeptName })
                .Where(res => res.DeptName == "Finance")
                .ToList();
            foreach (var emp in empFinanceDept)
            {
                Console.WriteLine($"Name : {emp.Name}, Department: {emp.DeptName}");
            }
            Console.WriteLine("\n");


            // 10. Display employees whose name starts with 'A'.
            var startsWithA = employees.Where(emp => emp.Name.StartsWith("A")).ToList();
            foreach (var emp in startsWithA)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();


            // 11. Display employees whose name ends with 'a'.
            var endsWithA = employees.Where(emp => emp.Name.EndsWith("a")).ToList();
            foreach (var emp in endsWithA)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();


            // 12. Display employees whose age is between 25 and 35 years.
            var ageBetween = employees.Where(emp => emp.Age >= 25 && emp.Age <= 35).ToList();
            foreach (var emp in ageBetween)
            {
                Console.WriteLine($"{emp.Name} - {emp.Age}");
            }
            Console.WriteLine();


            // 13. Display every skill of every employee.
            var allSkills = employees.SelectMany(emp => emp.Skills).ToList();
            foreach (var skill in allSkills)
            {
                Console.WriteLine(skill);
            }
            Console.WriteLine();


            // 14. Display all unique skills.
            var uniqueSkills = employees.SelectMany(emp => emp.Skills).Distinct().ToList();
            foreach (var skill in uniqueSkills)
            {
                Console.WriteLine(skill);
            }
            Console.WriteLine();


            // 15. Display employees who know the "C#" skill.
            var csharpEmp = employees.Where(emp => emp.Skills.Contains("C#")).ToList();
            foreach (var emp in csharpEmp)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();


            // 16. Display all distinct Department IDs.
            var deptIds = employees.Select(emp => emp.DeptId).Distinct().ToList();
            foreach (var id in deptIds)
            {
                Console.WriteLine(id);
            }
            Console.WriteLine();


            // 17. Display all distinct employee ages.
            var ages = employees.Select(emp => emp.Age).Distinct().ToList();
            foreach (var age in ages)
            {
                Console.WriteLine(age);
            }
            Console.WriteLine();


            // 18. Display the first employee.
            var firstEmp = employees.First();
            Console.WriteLine(firstEmp.Name);
            Console.WriteLine();


            // 19. Display the first three employees.
            var firstThree = employees.Take(3).ToList();
            foreach (var emp in firstThree)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();


            // 20. Skip the first employee and display the remaining employees.
            var skipOne = employees.Skip(1).ToList();
            foreach (var emp in skipOne)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();


            // 21. Skip the first three employees and display the remaining employees.
            var skipThree = employees.Skip(3).ToList();
            foreach (var emp in skipThree)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();


            // 22. Find the first employee from the IT department.
            var firstIT = employees.Join(
                departments,
                emp => emp.DeptId,
                dept => dept.DeptId,
                (emp, dept) => new { emp, dept.DeptName })
                .FirstOrDefault(x => x.DeptName == "IT");
            Console.WriteLine(firstIT.emp.Name);
            Console.WriteLine();


            // 23. Find the employee with Id = 999 using FirstOrDefault().
            var emp999 = employees.FirstOrDefault(emp => emp.Id == 999);
            Console.WriteLine(emp999 == null ? "Not Found" : emp999.Name);
            Console.WriteLine();


            // 24. Check whether any employee earns more than ₹90,000.
            Console.WriteLine(employees.Any(emp => emp.Salary > 90000));
            Console.WriteLine();


            // 25. Check whether the "Docker" skill exists in the company.
            Console.WriteLine(employees.Any(emp => emp.Skills.Contains("Docker")));
            Console.WriteLine();


            // 26. Display employee Name and Annual Salary.
            var annualSalary = employees.Select(emp => new
            {
                emp.Name,
                AnnualSalary = emp.Salary * 12
            });
            foreach (var emp in annualSalary)
            {
                Console.WriteLine($"{emp.Name} - {emp.AnnualSalary}");
            }
            Console.WriteLine();


            // 27. Display employee Name and total number of Skills.
            var skillCount = employees.Select(emp => new
            {
                emp.Name,
                TotalSkills = emp.Skills.Count
            });
            foreach (var emp in skillCount)
            {
                Console.WriteLine($"{emp.Name} - {emp.TotalSkills}");
            }
            Console.WriteLine();


            // 28. Display employees whose salary is between ₹70,000 and ₹90,000.
            var salaryRange = employees.Where(emp => emp.Salary >= 70000 && emp.Salary <= 90000);
            foreach (var emp in salaryRange)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();


            // 29. Display employees who know the "SQL" skill.
            var sqlEmp = employees.Where(emp => emp.Skills.Contains("SQL"));
            foreach (var emp in sqlEmp)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();


            // 30. Display employees who belong to the IT department and earn more than ₹80,000.
            var itSalary = employees.Join(
                departments,
                emp => emp.DeptId,
                dept => dept.DeptId,
                (emp, dept) => new { emp, dept.DeptName })
                .Where(x => x.DeptName == "IT" && x.emp.Salary > 80000);
            foreach (var emp in itSalary)
            {
                Console.WriteLine(emp.emp.Name);
            }
            Console.WriteLine();


            // 31. Display all skills of employees earning more than ₹80,000.
            var highSalarySkills = employees
                .Where(emp => emp.Salary > 80000)
                .SelectMany(emp => emp.Skills);
            foreach (var skill in highSalarySkills)
            {
                Console.WriteLine(skill);
            }
            Console.WriteLine();


            // 32. Display all skills of employees working in the IT department.
            var itSkills = employees
                .Where(emp => emp.DeptId == 2)
                .SelectMany(emp => emp.Skills);
            foreach (var skill in itSkills)
            {
                Console.WriteLine(skill);
            }
            Console.WriteLine();


            // 33. Retrieve only Employee objects.
            List<object> mixed = new List<object>
            {
                employees[0],
                "Hello",
                employees[1],
                500,
                employees[2],
                true
            };

            var employeeObjects = mixed.OfType<Employee>();
            foreach (var emp in employeeObjects)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();


            // 34. Retrieve only string values.
            var strings = mixed.OfType<string>();
            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();


            // 35. Return employees until Age becomes 32 or above.
            var takeWhileAge = employees.OrderBy(emp => emp.Age)
                                        .TakeWhile(emp => emp.Age < 32);
            foreach (var emp in takeWhileAge)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();


            // 36. Skip employees while Salary is greater than or equal to ₹80,000.
            var skipSalary = employees.SkipWhile(emp => emp.Salary >= 80000);

            foreach (var emp in skipSalary)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();


            // 37. Retrieve employee whose Id is 103 using Single().
            var singleEmp = employees.Single(emp => emp.Id == 103);
            Console.WriteLine(singleEmp.Name);
            Console.WriteLine();


            // 38. Retrieve employee whose Id is 999 using SingleOrDefault().
            var singleDefault = employees.SingleOrDefault(emp => emp.Id == 999);
            Console.WriteLine(singleDefault == null ? "Not Found" : singleDefault.Name);
            Console.WriteLine();


            // 39. Verify whether every employee has at least one skill.
            Console.WriteLine(employees.All(emp => emp.Skills.Count > 0));
            Console.WriteLine();


            // 40. Verify whether the "React" skill exists in the company.
            Console.WriteLine(employees.Any(emp => emp.Skills.Contains("React")));
            Console.WriteLine();


            // 41. Display names of employees older than 30 years.
            var older30 = employees.Where(emp => emp.Age > 30).Select(emp => emp.Name);

            foreach (var name in older30)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();


            // 42. Display unique skills of employees earning more than ₹80,000.
            var uniqueHighSalarySkills = employees
                .Where(emp => emp.Salary > 80000)
                .SelectMany(emp => emp.Skills)
                .Distinct();

            foreach (var skill in uniqueHighSalarySkills)
            {
                Console.WriteLine(skill);
            }
            Console.WriteLine();


            // 43. Display names of employees who know the "SQL" skill.
            var sqlNames = employees
                .Where(emp => emp.Skills.Contains("SQL"))
                .Select(emp => emp.Name);

            foreach (var name in sqlNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();


            // 44. Display the first employee who knows the "Azure" skill.
            var azureEmp = employees.FirstOrDefault(emp => emp.Skills.Contains("Azure"));
            Console.WriteLine(azureEmp.Name);
            Console.WriteLine();


            // 45. Check whether every IT employee earns more than ₹70,000.
            Console.WriteLine(
                employees.Where(emp => emp.DeptId == 2)
                         .All(emp => emp.Salary > 70000)
            );
            Console.WriteLine();


            // 46. Check whether any Finance employee knows the "SQL" skill.
            Console.WriteLine(
                employees.Where(emp => emp.DeptId == 3)
                         .Any(emp => emp.Skills.Contains("SQL"))
            );
            Console.WriteLine();


            // 47. Display the first two employee names.
            var firstTwoNames = employees.Take(2).Select(emp => emp.Name);

            foreach (var name in firstTwoNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();


            // 48. Skip the first two employees and display only their names.
            var skipTwoNames = employees.Skip(2).Select(emp => emp.Name);

            foreach (var name in skipTwoNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();


            // 49. Display unique skills of employees whose age is greater than 30 years.
            var uniqueSkillsAge30 = employees
                .Where(emp => emp.Age > 30)
                .SelectMany(emp => emp.Skills)
                .Distinct();

            foreach (var skill in uniqueSkillsAge30)
            {
                Console.WriteLine(skill);
            }
            Console.WriteLine();


            // 50. Check whether every employee knows either the "C#" skill or the "SQL" skill.
            Console.WriteLine(
                employees.All(emp =>
                    emp.Skills.Contains("C#") ||
                    emp.Skills.Contains("SQL"))
            );
            Console.WriteLine();
        }
    }
}
