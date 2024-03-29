using Susurri.Client.Abstractions;
using Susurri.Client.Entities;
using Susurri.Client.Security;
using Susurri.Client.DAL;

namespace Susurri.Client.Commands.Handlers;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;
    private readonly SusurriDbContext _context;
    
    public SignUpHandler(IPasswordManager passwordManager, IClock clock, SusurriDbContext context)
    {
        _passwordManager = passwordManager;
        _clock = clock;
        _context = context;
    }
    
    
    public async Task HandleAsync(SignUp command)
    {
        // validate input
        // validate if user already exist
        // create the user
        var securePassword = _passwordManager.Secure(command.Password);
        var user = new User(command.UserId, command.Username, securePassword, command.Role,
            _clock.Current());
        // save to db
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}