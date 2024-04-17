using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Susurri.Client.Services;

namespace Susurri.Client.Models;

internal sealed class SignUpModel : PageModel
{
    private readonly UserService _userService; // Inject UserService
    public SignUpModel(UserService userService)
    {
        _userService = userService;
    }

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

        if (_userService.UserExists(SignUp.Username))
        {
            ModelState.AddModelError(nameof(SignUp.Username), "Username already exists.");
            return Task.FromResult<IActionResult>(Page());
        }

        // Create the user
        _userService.SaveUser(SignUp);

        // Redirect to chat page after successful signup
        return Task.FromResult<IActionResult>(RedirectToPage("/chat"));
    }
}
