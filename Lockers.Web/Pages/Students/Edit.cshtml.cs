using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentService _studentService;

        public EditModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [BindProperty]
        public StudentDto Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Student = await _studentService.GetByIdAsync(id);
            if (Student == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _studentService.UpdateAsync(Student);
            return RedirectToPage("/Students/Index");
        }
    }
}