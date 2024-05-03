using Abstractions_ICommand = Susurri.Application.Abstractions.ICommand;
using ICommand = Susurri.Application.Abstractions.ICommand;

namespace Susurri.Application.Commands;

public record SignUp(Guid UserId, string Username, string Password, string Role) : Abstractions_ICommand;