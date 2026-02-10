using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemAdminAPI.DTOs;
using SystemAdminAPI.Entitties;
using AppSystemAdmin = SystemAdminAPI.DbContextAdmin.AppDbContextAdmin;

namespace SystemAdminAPI.Controllers  
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AppSystemAdmin _db;

        public AdminController(AppSystemAdmin context)
        {
            _db = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Admin>> GetAllAdmins()
        {
            var admins = _db.Admins.AsNoTracking().ToList();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public ActionResult<Admin> GetAdminById(int id)
        {
            var admin = _db.Admins.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult<CreateAdminDTO>> CreateAdmin([FromBody] CreateAdminDTO adminDTO)
        {
            var admin = new Admin
            {
                Name = adminDTO.Name,
                Email = adminDTO.Email,
                Password = adminDTO.Password
            };

            _db.Admins.Add(admin);
            await _db.SaveChangesAsync();

            var response = new Admin
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                Password = admin.Password,
            };

            return CreatedAtAction(nameof(GetAdminById), new { id = admin.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdmin(int id, [FromBody] Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            _db.Entry(admin).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Admins.Any(a => a.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmin(int id)
        {
            var admin = await _db.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _db.Admins.Remove(admin);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}