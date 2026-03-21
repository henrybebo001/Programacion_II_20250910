
using Web.Domain.Entities;
using Web.Application.Interfaces.Reposity;
using System.ComponentModel.DataAnnotations;
using Web.Domain.Repository;

namespace Web.Application.Services.AdminService
{
    public class AdminService : IAdminServices
    {
        private readonly IAdminRepository _repo;


        public AdminService(IAdminRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAdmin(Admin model, int id)
        {
            await _repo.AddAdmin(model, id);        
        }

        public async Task<Admin?> GetAdminById(int id)
        {
            var admin = await _repo.GetAdminById(id);
            return admin;
        }

        public async Task<IEnumerable<Admin>> GetAllAdmin()
        {
            var admin = await _repo.GetAllAdmin();
            return admin;
        }

        public async Task RemoveAdmin(int id)
        {
            await _repo.RemoveAdmin(id);
        }

        public async Task UpdateAdmin(Admin admin)
        {
            await _repo.UpdateAdmin(admin);
        }
    }
}