using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lockers.Web.Pages.Assignments
{
    public class CreateModel : PageModel
    {
        private readonly IAssignmentService _assignmentService;
        private readonly ILockerService _lockerService;
        private readonly IStudentService _studentService;

        public CreateModel(IAssignmentService assignmentService, ILockerService lockerService, IStudentService studentService)
        {
            _assignmentService = assignmentService;
            _lockerService = lockerService;
            _studentService = studentService;
        }

        [BindProperty]
        public AssignmentDto Assignment { get; set; } = new();

        public List<SelectListItem> LockerOptions { get; set; } = new();
        public List<SelectListItem> StudentOptions { get; set; } = new();

        public async Task OnGetAsync()
        {
            var lockers = await _lockerService.GetAllAsync();
            var students = await _studentService.GetAllAsync();

            LockerOptions = lockers.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = $"{l.Number} - {l.Location}"
            }).ToList();

            StudentOptions = students.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = $"{s.Name} - {s.StudentId}"
            }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Assignment.StartDate = DateTime.SpecifyKind(Assignment.StartDate, DateTimeKind.Utc);
                Assignment.EndDate = DateTime.SpecifyKind(Assignment.EndDate, DateTimeKind.Utc);
                await _assignmentService.CreateAsync(Assignment);
                return RedirectToPage("/Assignments/Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await OnGetAsync();
                return Page();
            }
        }
    }
}