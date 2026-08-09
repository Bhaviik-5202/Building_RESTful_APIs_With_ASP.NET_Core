using Lab_10_EFCore_CRUD.Data;
using Lab_10_EFCore_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_10_EFCore_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PermissionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permissions = await _context.Permissions.ToListAsync();

            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermission(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);

            if (permission == null)
                return NotFound();

            return Ok(permission);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Permission permission)
        {
            _context.Permissions.Add(permission);

            await _context.SaveChangesAsync();

            return Ok(permission);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Permission permission)
        {
            if (id != permission.PermissionId)
                return BadRequest();

            var oldPermission = await _context.Permissions.FindAsync(id);

            if (oldPermission == null)
                return NotFound();

            oldPermission.PermissionName = permission.PermissionName;
            oldPermission.Description = permission.Description;

            await _context.SaveChangesAsync();

            return Ok(oldPermission);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);

            if (permission == null)
                return NotFound();

            _context.Permissions.Remove(permission);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
