using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Susurri.Client.Services;

namespace Susurri.Client.Models
{
    internal sealed class SignUpModel : PageModel
    {
        private readonly UserService _userService;

        public SignUpModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public SignUpViewModel SignUp { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_userService.UserExists(SignUp.Username))
            {
                ModelState.AddModelError(nameof(SignUp.Username), "Username already exists.");
                return Page();
            }

            // Create the user asynchronously
            await _userService.SaveUser(SignUp);

            // Redirect to chat page after successful signup
            return RedirectToPage("/chat");
        }
    }
}