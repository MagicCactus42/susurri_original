using Susurri.Client.Abstractions;
using Susurri.Client.Models;
using Susurri.Core.Entities;
using Susurri.Core.Exceptions;
using Susurri.Core.ValueObjects;

namespace Susurri.Application.Services;

internal sealed class UserService : IUserService
{
    private readonly ISusurriDbContext _context;
    private readonly IPasswordManager _passwordManager;

    public UserService(ISusurriDbContext context, IPasswordManager passwordManager)
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
        if (UserExists(model.Username))
        {
            throw new UsernameAlreadyInUseException(model.Username);
        }
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
