using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Repository
{
    public interface IAdminRepository
    {
        public Task<IEnumerable<Admin>> GetAllAdmin();
        public Task<Admin> GetAdminById(int id);
        public Task AddAdmin(Admin admin, int id);
        public Task UpdateAdmin(Admin admin);

        public Task RemoveAdmin(Admin admin);
    }
}