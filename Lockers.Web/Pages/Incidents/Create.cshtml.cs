using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.Incidents
{
    public class CreateModel : PageModel
    {
        private readonly IIncidentService _incidentService;

        public CreateModel(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [BindProperty]
        public IncidentDto Incident { get; set; } = new();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _incidentService.CreateAsync(Incident);
            return RedirectToPage("/Incidents/Index");
        }
    }
}