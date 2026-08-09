using Lab_08_StudentSubjectAPI_With_HTTP_Status_Codes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_08_StudentSubjectAPI_With_HTTP_Status_Codes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private static readonly List<Subject> Subjects = new List<Subject>
        {
            new Subject { Id = 1, Name = "C++" },
            new Subject { Id = 2, Name = "ASP.NET Core" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Subjects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subject = Subjects.FirstOrDefault(x => x.Id == id);

            if (subject == null)
                return NotFound("Subject not found.");

            return Ok(subject); // Return the subject with a 200 OK status code
        }

        [HttpPost]
        public IActionResult Add(Subject subject)
        {
            if (subject.Id <= 0 || string.IsNullOrWhiteSpace(subject.Name))
                return BadRequest("Invalid subject data.");

            if (Subjects.Any(x => x.Id == subject.Id))
                return Conflict("Subject ID already exists.");

            Subjects.Add(subject);

            return CreatedAtAction(
                nameof(GetById),
                new { id = subject.Id },
                subject
            ); // Return the created subject with a 201 Created status code
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Subject updatedSubject)
        {
            var subject = Subjects.FirstOrDefault(x => x.Id == id);

            if (subject == null)
                return NotFound("Subject not found.");

            if (string.IsNullOrWhiteSpace(updatedSubject.Name))
                return BadRequest("Invalid subject data.");

            subject.Name = updatedSubject.Name;

            return NoContent(); //  Return a 204 No Content status code to indicate successful update without returning any content
        } 

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var subject = Subjects.FirstOrDefault(x => x.Id == id);

            if (subject == null)
                return NotFound("Subject not found.");

            Subjects.Remove(subject);

            return NoContent(); // Return a 204 No Content status code to indicate successful deletion without returning any content
        }
    }
}
