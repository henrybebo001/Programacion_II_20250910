using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.Incidents
{
    public class DeleteModel : PageModel
    {
        private readonly IIncidentService _incidentService;

        public DeleteModel(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        public IncidentDto Incident { get; set; } = new();

        public async Task OnGetAsync(int id)
        {
            Incident = await _incidentService.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _incidentService.DeleteAsync(id);
            return RedirectToPage("/Incidents/Index");
        }
    }
}