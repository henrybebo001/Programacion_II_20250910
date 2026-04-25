using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentService _studentService;

        public IndexModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public List<StudentDto> StudentList { get; set; } = new();

        public async Task OnGetAsync()
        {
            StudentList = await _studentService.GetAllAsync();
        }
    }
}