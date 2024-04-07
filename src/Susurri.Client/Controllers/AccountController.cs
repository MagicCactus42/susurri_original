using Microsoft.AspNetCore.Mvc;
using Susurri.Client.Models;
using Susurri.Client.Services;

namespace Susurri.Client.Controllers;

[ApiController]
[Route("[controller]")]
internal sealed class AccountController(UserService userService) : ControllerBase
{
    [HttpPost("signup")]
    public IActionResult SignUp(SignUpViewModel model)
    {
        userService.SaveUser(model);
        return NoContent();
    }
}