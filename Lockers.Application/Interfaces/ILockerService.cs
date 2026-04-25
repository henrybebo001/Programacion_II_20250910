using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lockers.Application.DTOs;

namespace Lockers.Application.Interfaces
{
    public interface ILockerService
    {
        Task<List<LockerDto>> GetAllAsync();
        Task<LockerDto> GetByIdAsync(int id);
        Task CreateAsync(LockerDto dto);
        Task UpdateAsync(LockerDto dto);
        Task DeleteAsync(int id);
    }
}
