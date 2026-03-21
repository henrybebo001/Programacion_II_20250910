using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemAdminAPI.DTOs;
using Web.Application.Services.AdminService;
using Web.Domain.Entities;
using Web.Domain.Models;
using Web.Domain.Repository;
using AppSystemAdmin = Web.Infrastructure.Context.SystemAdminApiContext;

namespace SystemAdminAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _db;

        public AdminController(IAdminServices context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAllAdmins()
        {
            var admins = await _db.GetAllAdmin();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdminById(int id)
        {
            var admin = await _db.GetAdminById(id);
            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult<CreateAdminDTO>> CreateAdmin([FromBody] CreateAdminDTO adminDTO, int id)
        {
            var admin = new Admin
            {
                Name = adminDTO.Name,
                Email = adminDTO.Email,
                Password = adminDTO.Password
            };

             await _db.AddAdmin(admin, id );

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
            await _db.UpdateAdmin(admin);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAdmin(int id)
        {
            await _db.RemoveAdmin(id);
            return NoContent();
        }
    }
}