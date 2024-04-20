using Susurri.Client.DAL;
using Susurri.Client.Entities;
using Susurri.Client.Models;
using Susurri.Client.Security;
using Susurri.Client.ValueObjects;

namespace Susurri.Client.Services;

internal sealed class UserService(SusurriDbContext context, IPasswordManager passwordManager)
{
    public bool UserExists(string username)
    {
        return context.Users.Any(x => x.Username == username);
    }
        
    public void SaveUser(SignUpViewModel model)
    {
        var user = new User(
        
            new UserId(Guid.NewGuid()),
            model.Username,
            passwordManager.Secure(model.Password),
            Role.User(),
            DateTime.Now
        );
        context.Users.Add(user);
        context.SaveChanges();
    }
    public bool ValidatePassword(string username, string password)
    {
        var user = context.Users.FirstOrDefault(x => x.Username == username);
        if (user != null)
        {
            return passwordManager.Validate(password, user.Password);
        }
        return false;
    }
}