using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.LockersPages
{
    public class DeleteModel : PageModel
    {
        private readonly ILockerService _lockerService;

        public DeleteModel(ILockerService lockerService)
        {
            _lockerService = lockerService;
        }

        public LockerDto Locker { get; set; } = new();

        public async Task OnGetAsync(int id)
        {
            Locker = await _lockerService.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _lockerService.DeleteAsync(id);
            return RedirectToPage("/LockersPages/Index");
        }
    }
}