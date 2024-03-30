using Susurri.Client.Abstractions;

namespace Susurri.Client.Commands;

public record SignIn(string Username, string Password) : ICommand;