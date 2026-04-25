using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Lockers.Domain;
using Lockers.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Lockers.Application.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly AppDbContext _context;

        public AssignmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AssignmentDto>> GetAllAsync()
        {
            return await _context.Assignments
                .Select(a => new AssignmentDto
                {
                    Id = a.Id,
                    LockerId = a.LockerId,
                    StudentId = a.StudentId,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    IsActive = a.IsActive
                }).ToListAsync();
        }

        public async Task<AssignmentDto> GetByIdAsync(int id)
        {
            var a = await _context.Assignments.FindAsync(id);
            if (a == null) return null;
            return new AssignmentDto { Id = a.Id, LockerId = a.LockerId, StudentId = a.StudentId, StartDate = a.StartDate, EndDate = a.EndDate, IsActive = a.IsActive };
        }

        public async Task CreateAsync(AssignmentDto dto)
        {
            var existingAssignment = await _context.Assignments
                .AnyAsync(a => a.LockerId == dto.LockerId && a.IsActive);

            if (existingAssignment)
                throw new InvalidOperationException("This locker is already assigned to another student.");

            var assignment = new Assignment(dto.LockerId, dto.StudentId, dto.StartDate, dto.EndDate);
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task RenewAsync(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null) return;
            assignment.Renew();
            await _context.SaveChangesAsync();
        }

        public async Task RenewAsync(int id, int extraDays)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null) return;
            assignment.Renew(extraDays);
            await _context.SaveChangesAsync();
        }

        public async Task RenewAsync(int id, DateTime newEndDate)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null) return;
            assignment.Renew(newEndDate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null) return;

            var incidents = _context.Incidents.Where(i => i.AssignmentId == id);
            _context.Incidents.RemoveRange(incidents);

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
        }
    }
}