using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.Assignments
{
    public class RenewModel : PageModel
    {
        private readonly IAssignmentService _assignmentService;

        public RenewModel(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        public AssignmentDto Assignment { get; set; } = new();

        [BindProperty]
        public int ExtraDays { get; set; }

        public async Task OnGetAsync(int id)
        {
            Assignment = await _assignmentService.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _assignmentService.RenewAsync(id, ExtraDays);
            return RedirectToPage("/Assignments/Index");
        }
    }
}