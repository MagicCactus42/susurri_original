namespace Susurri.Client.Exceptions;

public sealed class InvalidRoleException(string role) : CustomException($"Role: '{role}' is invalid.")
{
    public string Role { get; } = role;
}