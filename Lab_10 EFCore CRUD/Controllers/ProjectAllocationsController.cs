using Lab_10_EFCore_CRUD.Data;
using Lab_10_EFCore_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_10_EFCore_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAllocationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectAllocationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllocations()
        {
            var allocations = await _context.ProjectAllocations
                .Include(a => a.Project)
                .Include(a => a.User)
                .ToListAsync();

            return Ok(allocations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllocation(int id)
        {
            var allocation = await _context.ProjectAllocations
                .Include(a => a.Project)
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.ProjectAllocationId == id);

            if (allocation == null)
                return NotFound();

            return Ok(allocation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectAllocation allocation)
        {
            _context.ProjectAllocations.Add(allocation);

            await _context.SaveChangesAsync();

            return Ok(allocation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            ProjectAllocation allocation)
        {
            if (id != allocation.ProjectAllocationId)
                return BadRequest();

            var oldAllocation =
                await _context.ProjectAllocations.FindAsync(id);

            if (oldAllocation == null)
                return NotFound();

            oldAllocation.ProjectId = allocation.ProjectId;
            oldAllocation.UserId = allocation.UserId;
            oldAllocation.AllocationRole = allocation.AllocationRole;

            await _context.SaveChangesAsync();

            return Ok(oldAllocation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var allocation =
                await _context.ProjectAllocations.FindAsync(id);

            if (allocation == null)
                return NotFound();

            _context.ProjectAllocations.Remove(allocation);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
