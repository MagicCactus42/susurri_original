using Infrastructure_Abstractions_ICommand = Susurri.Infrastructure.Abstractions.ICommand;

namespace Susurri.Api.Commands;

public record SignUp(Guid UserId, string Username, string Password, string Role) : Infrastructure_Abstractions_ICommand;