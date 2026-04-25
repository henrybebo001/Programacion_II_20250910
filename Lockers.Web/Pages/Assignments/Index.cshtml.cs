using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.Assignments
{
    public class IndexModel : PageModel
    {
        private readonly IAssignmentService _assignmentService;

        public IndexModel(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        public List<AssignmentDto> AssignmentList { get; set; } = new();

        public async Task OnGetAsync()
        {
            AssignmentList = await _assignmentService.GetAllAsync();
        }
    }
}