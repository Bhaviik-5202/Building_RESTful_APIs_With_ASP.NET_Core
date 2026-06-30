using Lab_07_Student_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_07_Student_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> Students =
            [
                new Student { id = 1, name = "Bhaviik"},
                new Student { id = 2, name = "Ronak"},
                new Student { id = 3, name = "Deep"}
            ];

        // 1. GET: api/Student
        [HttpGet]
        public ActionResult<List<Student>> GetStudent()
        {
            return Ok(Students);
        }

        // 2. POST : api/Student
        [HttpPost]
        public ActionResult<List<Student>> AddStudent(Student newStudent)
        {
            Students.Add(newStudent);
            return Ok(Students);
        }

        // 3. PATCH : api/Student/{id}
        [HttpPatch]
        public ActionResult<List<Student>> UpdateStudent(int id, Student updatedStudent)
        {
            var student = Students.FirstOrDefault(s => s.id == id);
            if (!string.IsNullOrEmpty(updatedStudent.name))
            {
                student.name = updatedStudent.name;
            }
            return Ok(Students);
        }

        // 4. DELETE : api/Student/{id}
        [HttpDelete]
        public ActionResult<List<Student>> DeleteStudet(int id)
        {
            var student = Students.FirstOrDefault(s => s.id == id);
            Students.Remove(student);
            return Ok(Students);
        }
    }
}
