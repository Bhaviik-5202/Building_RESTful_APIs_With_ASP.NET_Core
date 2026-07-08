using Lab_07_Student_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudentSubjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>()
        {
            new Student{Id=1,Name="Bhavik",Age=20,City="Rajkot"},
            new Student{Id=2,Name="Rahul",Age=21,City="Ahmedabad"},
            new Student{Id=3,Name="Priya",Age=19,City="Surat"},
            new Student{Id=4,Name="Amit",Age=22,City="Vadodara"},
            new Student{Id=5,Name="Neha",Age=20,City="Junagadh"}
        };

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound("Student Not Found");

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            students.Add(student);
            return Ok("Student Added Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound("Student Not Found");

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.City = updatedStudent.City;

            return Ok("Student Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound("Student Not Found");

            students.Remove(student);

            return Ok("Student Deleted Successfully");
        }
    }
}