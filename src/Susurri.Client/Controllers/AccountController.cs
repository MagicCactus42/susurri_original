using Microsoft.AspNetCore.Mvc;
using Susurri.Client.Models;
using Susurri.Client.Services;

namespace Susurri.Client.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost("signup")]
    public IActionResult SignUp(SignUpViewModel model)
    {
        // tu zaczac jutro
    }
}