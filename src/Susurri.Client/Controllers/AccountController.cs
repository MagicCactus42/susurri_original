using Microsoft.AspNetCore.Mvc;
using Susurri.Client.Models;
using Susurri.Client.Services;

namespace Susurri.Client.Controllers;

[ApiController]
[Route("[controller]")]
internal sealed class AccountController : ControllerBase
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }
    [HttpPost("signup")]
    public IActionResult SignUp(SignUpViewModel model)
    {
        _userService.SaveUser(model);
        return NoContent();
    }
}