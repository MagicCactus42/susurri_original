using Susurri.Client.Abstractions;
using Susurri.Client.Entities;
using Susurri.Client.Security;

namespace Susurri.Client.Commands.Handlers;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;
    
    public SignUpHandler(IPasswordManager passwordManager, IClock clock)
    {
        _passwordManager = passwordManager;
        _clock = clock;
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
    }
}