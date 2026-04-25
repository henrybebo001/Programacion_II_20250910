using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lockers.Application.DTOs;

namespace Lockers.Application.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto> GetByIdAsync(int id);
        Task CreateAsync(StudentDto dto);
        Task UpdateAsync(StudentDto dto);
        Task DeleteAsync(int id);
    }
}
