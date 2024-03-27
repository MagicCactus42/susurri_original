using System.Windows.Input;
using Susurri.Client.Abstractions;
using ICommand = Susurri.Client.Abstractions.ICommand;

namespace Susurri.Client.Commands;

public record SignUp(Guid UserId, string Username, string Password, string Role) : ICommand;