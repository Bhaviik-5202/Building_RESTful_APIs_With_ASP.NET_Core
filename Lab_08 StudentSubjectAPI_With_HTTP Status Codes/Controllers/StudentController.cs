using Lab_08_StudentSubjectAPI_With_HTTP_Status_Codes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_08_StudentSubjectAPI_With_HTTP_Status_Codes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static readonly List<Student> Students = new List<Student>
        {
            new Student { Id = 1, Name = "Bhavik", SubjectId = 1 },
            new Student { Id = 2, Name = "Rahul", SubjectId = 2 }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound("Student not found.");

            return Ok(student); // 200 OK with the student data
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (student.Id <= 0 || string.IsNullOrWhiteSpace(student.Name))
                return BadRequest("Invalid student data.");

            if (Students.Any(x => x.Id == student.Id))
                return Conflict("Student ID already exists.");

            Students.Add(student);

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                student
            ); // 201 Created with the location of the new student
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student updatedStudent)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound("Student not found.");

            if (string.IsNullOrWhiteSpace(updatedStudent.Name))
                return BadRequest("Invalid student data.");

            student.Name = updatedStudent.Name;
            student.SubjectId = updatedStudent.SubjectId;

            return NoContent(); // 204 No Content to indicate successful update without returning data
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound("Student not found.");

            Students.Remove(student);

            return NoContent(); // 204 No Content to indicate successful deletion without returning data
        }
    }
}
