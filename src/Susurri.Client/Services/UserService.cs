using Susurri.Client.DAL;
using Susurri.Client.Entities;
using Susurri.Client.Models;
using Susurri.Client.Security;
using Susurri.Client.ValueObjects;

namespace Susurri.Client.Services;

internal sealed class UserService
{
    private readonly SusurriDbContext _context;
    private readonly IPasswordManager _passwordManager;

    public UserService(SusurriDbContext context, IPasswordManager passwordManager)
    {
        _context = context;
        _passwordManager = passwordManager;
    }

    public bool UserExists(string username)
    {
        return _context.Users.Any(x => x.Username == username);
    }

    public async Task SaveUser(SignUpViewModel model)
    {
        var user = new User(
            new UserId(Guid.NewGuid()),
            model.Username,
            _passwordManager.Secure(model.Password),
            Role.User(),
            DateTime.UtcNow
        );
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public bool ValidatePassword(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(x => x.Username == username);
        if (user != null)
        {
            return _passwordManager.Validate(password, user.Password);
        }
        return false;
    }
}
