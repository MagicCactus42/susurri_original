using Susurri.Client.Models;

namespace Susurri.Client.Abstractions;

public interface IUserService
{
    bool UserExists(string username);
    Task SaveUser(SignUpViewModel model);
    bool ValidatePassword(string username, string password);
}