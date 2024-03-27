using MudBlazor;

namespace Susurri.Client.Exceptions;

public sealed class InvalidPasswordException : CustomException
{
    public InvalidPasswordException() : base("Invalid password.")
    {
    }
}