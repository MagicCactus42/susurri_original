using System.Reflection.Metadata;
using Susurri.Client.Abstractions;
using Susurri.Client.Repositories;
using Susurri.Client.Security;

namespace Susurri.Client.Commands.Handlers;


internal sealed class SignInHandler : ICommandHandler<SignIn>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;

    public SignInHandler(IUserRepository userRepository, IPasswordManager passwordManager, IClock clock)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _clock = clock;
    }

    public async Task HandleAsync(SignIn command)
    {
        
    }
    
}