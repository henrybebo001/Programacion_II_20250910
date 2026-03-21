using Microsoft.EntityFrameworkCore;
using Web.Domain.Entities;
using Web.Domain.Models;
using Web.Application.Interfaces.Reposity;
using AppAdminDb = Web.Infrastructure.Context.SystemAdminApiContext;

namespace Web.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppAdminDb db;

        public AdminRepository(AppAdminDb _db)
        {
            db = _db;
        }

        public async Task AddAdmin(Admin admin, int id)
        {
            var entity = new AdminModel
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                Password = admin.Password
            };
            await db.Admins.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task<Admin?> GetAdminById(int id)
        {
            var entity = await db.Admins
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (entity is null) return null;

            return new Admin
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password
            };
        }

        public async Task<IEnumerable<Admin>> GetAllAdmin()
        {
            var entities = await db.Admins
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(entity => new Admin
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password
            });
        }

        public async Task RemoveAdmin(int id)
        {
            var entity = await db.Admins.FindAsync(id);

            if (entity is null) return;

            db.Admins.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAdmin(Admin admin)
        {
            var entity = await db.Admins.FindAsync(admin.Id);

            if (entity is null) return;

            entity.Name = admin.Name;
            entity.Email = admin.Email;
            entity.Password = admin.Password;

            db.Admins.Update(entity);
            await db.SaveChangesAsync();
        }
    }
}