using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Lockers.Domain;
using Lockers.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lockers.Application.Services
{
    public class LockerService : ILockerService
    {
        private readonly AppDbContext _context;

        public LockerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LockerDto>> GetAllAsync()
        {
            return await _context.Lockers
                .Select(l => new LockerDto
                {
                    Id = l.Id,
                    Number = l.Number,
                    Location = l.Location,
                    Size = l.Size,
                    Status = l.Status.ToString()
                }).ToListAsync();
        }

        public async Task<LockerDto> GetByIdAsync(int id)
        {
            var l = await _context.Lockers.FindAsync(id);
            if (l == null) return null;
            return new LockerDto { Id = l.Id, Number = l.Number, Location = l.Location, Size = l.Size, Status = l.Status.ToString() };
        }

        public async Task CreateAsync(LockerDto dto)
        {
            var locker = new Locker(dto.Number, dto.Location, dto.Size);
            _context.Lockers.Add(locker);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LockerDto dto)
        {
            var locker = await _context.Lockers.FindAsync(dto.Id);
            if (locker == null) return;
            locker.Number = dto.Number;
            locker.Location = dto.Location;
            locker.Size = dto.Size;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var locker = await _context.Lockers.FindAsync(id);
            if (locker == null) return;
            _context.Lockers.Remove(locker);
            await _context.SaveChangesAsync();
        }
    }
}