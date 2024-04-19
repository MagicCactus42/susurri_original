using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Susurri.Client.Services;

namespace Susurri.Client.Models;

internal sealed class SignUpModel(UserService userService) : PageModel
{
    // Inject UserService

    [BindProperty]
    public SignUpViewModel SignUp { get; set; }

    public void OnGet()
    {
    }

    public Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Task.FromResult<IActionResult>(Page());
        }

        if (userService.UserExists(SignUp.Username))
        {
            ModelState.AddModelError(nameof(SignUp.Username), "Username already exists.");
            return Task.FromResult<IActionResult>(Page());
        }

        // Create the user
        userService.SaveUser(SignUp);

        // Redirect to chat page after successful signup
        return Task.FromResult<IActionResult>(RedirectToPage("/chat"));
    }
}
