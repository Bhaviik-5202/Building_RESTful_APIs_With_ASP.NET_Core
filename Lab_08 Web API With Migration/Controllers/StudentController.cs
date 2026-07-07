using Lab_08_Web_API_With_Migration.Data;
using Lab_08_Web_API_With_Migration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_08_Web_API_With_Migration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET : api/students
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        // GET : api/students/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST : api/students
        [HttpPost]
        public async Task<ActionResult> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student); // 201
        }

        // PUT : api/students/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, Student student) 
        {
            if (id != student.Id)
            {
                return BadRequest(); // 400 Bad Request
            }
            _context.Entry(student).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
            
            return Ok(student);
        }

        // DELETE : api/students/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound(); // 404 Not Found
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
    }
}
