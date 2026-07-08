using Lab_08_Web_API_With_Migration.Data;
using Lab_08_Web_API_With_Migration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_08_Web_API_With_Migration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubjectController(AppDbContext context)
        {
            _context = context;
        }

        // GET : api/subjects
        [HttpGet]
        public async Task<ActionResult> GetSubject()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return Ok(subjects);    
        }

        // GET : api/subjects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        // POST : api/subjects
        [HttpPost]
        public async Task<ActionResult> CreateSubject(Subject subject)
        {
            //subject.Id = 0;
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return Ok(subject); // 201
        }

        // PUT : api/subjects/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubject(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest(); // 400 Bad Request
            }
            _context.Entry(subject).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(subject);
        }

        // DELETE : api/subjects/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound(); // 404 Not Found
            }
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return Ok(subject);
        }
    }
}
