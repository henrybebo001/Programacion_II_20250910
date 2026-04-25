using Lockers.Application.DTOs;
using Lockers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lockers.Web.Pages.LockersPages
{
    public class CreateModel : PageModel
    {
        private readonly ILockerService _lockerService;

        public CreateModel(ILockerService lockerService)
        {
            _lockerService = lockerService;
        }

        [BindProperty]
        public LockerDto Locker { get; set; } = new();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            await _lockerService.CreateAsync(Locker);
            return RedirectToPage("/LockersPages/Index");
        }
    }
}