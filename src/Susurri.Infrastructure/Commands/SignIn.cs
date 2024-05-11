using System.Windows.Input;

namespace Susurri.Infrastructure.Commands
{
    public record SignIn(string Username, string Password) : Infrastructure.Abstractions.ICommand;
}
