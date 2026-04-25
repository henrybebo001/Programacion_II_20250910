using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.Assignments
{
    public class DeleteModel : PageModel
    {
        private readonly IAssignmentService _assignmentService;

        public DeleteModel(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        public AssignmentDto Assignment { get; set; } = new();

        public async Task OnGetAsync(int id)
        {
            Assignment = await _assignmentService.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _assignmentService.DeleteAsync(id);
            return RedirectToPage("/Assignments/Index");
        }
    }
}