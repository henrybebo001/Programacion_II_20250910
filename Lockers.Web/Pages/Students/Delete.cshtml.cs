using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentService _studentService;

        public DeleteModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public StudentDto Student { get; set; } = new();

        public async Task OnGetAsync(int id)
        {
            Student = await _studentService.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _studentService.DeleteAsync(id);
            return RedirectToPage("/Students/Index");
        }
    }
}