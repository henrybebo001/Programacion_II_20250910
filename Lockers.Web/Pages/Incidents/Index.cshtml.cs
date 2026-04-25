using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.Incidents
{
    public class IndexModel : PageModel
    {
        private readonly IIncidentService _incidentService;

        public IndexModel(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        public List<IncidentDto> IncidentList { get; set; } = new();

        public async Task OnGetAsync()
        {
            IncidentList = await _incidentService.GetAllAsync();
        }
    }
}