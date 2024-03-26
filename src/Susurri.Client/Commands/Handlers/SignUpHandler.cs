using Susurri.Client.Abstractions;
using Susurri.Client.Entities;

namespace Susurri.Client.Commands.Handlers;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IClock _clock;
    
    public SignUpHandler(IClock clock)
    {
        _clock = clock;
    }
    
    
    public async Task HandleAsync(SignUp command)
    {

        // validate input
        // validate if user already exist
        // create the user
        var user = new User(command.UserId, command.Email, command.Username, command.Password, command.Role,
            _clock.Current());
        // save to db
    }
}