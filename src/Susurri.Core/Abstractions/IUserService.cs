using Susurri.Core.Models;

namespace Susurri.Core.Abstractions;

public interface IUserService
{
    bool UserExists(string username);
    Task SaveUser(SignUpViewModel model);
    bool ValidatePassword(string username, string password);
}