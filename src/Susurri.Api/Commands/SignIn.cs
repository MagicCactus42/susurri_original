using Susurri.Application.Abstractions;

namespace Susurri.Api.Commands
{
    public record SignIn(string Username, string Password) : ICommand;
}
