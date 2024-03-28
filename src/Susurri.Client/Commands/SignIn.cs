using Susurri.Client.Abstractions;

namespace Susurri.Client.Commands;

public record SignIn(string Email, string Password) : ICommand;