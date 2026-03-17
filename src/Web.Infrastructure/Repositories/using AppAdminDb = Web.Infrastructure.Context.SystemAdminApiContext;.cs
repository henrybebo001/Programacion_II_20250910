using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Models;
using Web.Domain.Repository;

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
            await db.Admins.AddAsync(admin);
            await db.SaveChangesAsync();
        }

        public async Task<Admin?> GetAdminById(int id)
        {
            return await db.Admins
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Admin>> GetAllAdmin()
        {
            return await db.Admins
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task RemoveAdmin(Admin admin)
        {
            db.Remove(admin);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAdmin(Admin admin)
        {
            db.Admins.Update(admin);
            await db.SaveChangesAsync();
        }
    }
}