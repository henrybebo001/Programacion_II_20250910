using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Lockers.Domain;
using Lockers.Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace Lockers.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<StudentDto>> GetAllAsync()
        {
            return await _context.Students
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    StudentId = s.StudentId,
                    Grade = s.Grade,
                    Email = s.Email
                }).ToListAsync();
        }
        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var s = await _context.Students.FindAsync(id);
            if (s == null) return null;
            return new StudentDto { Id = s.Id, Name = s.Name, StudentId = s.StudentId, Grade = s.Grade, Email = s.Email };
        }
        public async Task CreateAsync(StudentDto dto)
        {
            var student = new Student(dto.Name, dto.StudentId, dto.Grade, dto.Email);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(StudentDto dto)
        {
            var student = await _context.Students.FindAsync(dto.Id);
            if (student == null) return;
            student.Name = dto.Name;
            student.StudentId = dto.StudentId; 
            student.Grade = dto.Grade;
            student.Email = dto.Email;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}