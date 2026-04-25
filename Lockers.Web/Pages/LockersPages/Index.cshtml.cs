using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.LockersPages
{
    public class IndexModel : PageModel
    {
        private readonly ILockerService _lockerService;

        public IndexModel(ILockerService lockerService)
        {
            _lockerService = lockerService;
        }

        public List<LockerDto> LockerList { get; set; } = new();

        public async Task OnGetAsync()
        {
            LockerList = await _lockerService.GetAllAsync();
        }
    }
}