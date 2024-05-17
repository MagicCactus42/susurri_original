using Susurri.Application.Abstractions;
using Infrastructure_Abstractions_ICommand = Susurri.Application.Abstractions.ICommand;

namespace Susurri.Api.Commands;

public record SignUp(Guid UserId, string Username, string Password, string Role) : ICommand;