using Abstractions_ICommand = Susurri.Infrastructure.Abstractions.ICommand;
using Applicatio_Abstractions_ICommand = Susurri.Infrastructure.Abstractions.ICommand;
using ICommand = Susurri.Infrastructure.Abstractions.ICommand;
using Infrastructure_Abstractions_ICommand = Susurri.Infrastructure.Abstractions.ICommand;

namespace Susurri.Infrastructure.Commands;

public record SignUp(Guid UserId, string Username, string Password, string Role) : Infrastructure_Abstractions_ICommand;