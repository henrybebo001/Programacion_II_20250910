using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Lockers.Domain;
using Lockers.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Lockers.Application.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly AppDbContext _context;

        public IncidentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<IncidentDto>> GetAllAsync()
        {
            return await _context.Incidents
                .Select(i => new IncidentDto
                {
                    Id = i.Id,
                    Type = i.Type.ToString(),
                    Description = i.Description,
                    AssignmentId = i.AssignmentId
                }).ToListAsync();
        }

        public async Task<IncidentDto> GetByIdAsync(int id)
        {
            var i = await _context.Incidents.FindAsync(id);
            if (i == null) return null;
            return new IncidentDto { Id = i.Id, Type = i.Type.ToString(), Description = i.Description, AssignmentId = i.AssignmentId };
        }

        public async Task CreateAsync(IncidentDto dto)
        {
            var incident = new Incident(Enum.Parse<IncidentType>(dto.Type), dto.Description, dto.AssignmentId);
            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null) return;
            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();
        }
    }
}