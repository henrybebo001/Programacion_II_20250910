using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lockers.Application.DTOs;

namespace Lockers.Application.Interfaces
{
    public interface IAssignmentService
    {
        Task<List<AssignmentDto>> GetAllAsync();
        Task<AssignmentDto> GetByIdAsync(int id);
        Task CreateAsync(AssignmentDto dto);
        Task RenewAsync(int id);
        Task RenewAsync(int id, int extraDays);
        Task RenewAsync(int id, DateTime newEndDate);
        Task DeleteAsync(int id);
    }
}
