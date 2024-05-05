using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Susurri.Core.Abstractions;
using Susurri.Core.Exceptions;

namespace Susurri.Core.Models
{
    internal sealed class SignUpModel : PageModel
    {
        private readonly IUserService _userService;

        public SignUpModel(IUserService userService)
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
                throw new UsernameAlreadyInUseException(SignUp.Username);
            }
            
            await _userService.SaveUser(SignUp);
            
            return RedirectToPage("/chat");
        }
    }
}