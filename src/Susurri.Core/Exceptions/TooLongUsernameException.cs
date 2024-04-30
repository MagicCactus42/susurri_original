namespace Susurri.Core.Exceptions;

public class TooLongUsernameException(string userName) : CustomException($"Username: '{userName}' is too long.")
{
    public string UserName { get; } = userName;
}