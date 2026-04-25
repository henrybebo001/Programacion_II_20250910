using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lockers.Application.DTOs;

namespace Lockers.Application.Interfaces
{
    public interface IIncidentService
    {
        Task<List<IncidentDto>> GetAllAsync();
        Task<IncidentDto> GetByIdAsync(int id);
        Task CreateAsync(IncidentDto dto);
        Task DeleteAsync(int id);
    }
}
