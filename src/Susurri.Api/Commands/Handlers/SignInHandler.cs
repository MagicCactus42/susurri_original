using Susurri.Application.Abstractions;
using Susurri.Core.Abstractions;
using Susurri.Core.Exceptions;
using Susurri.Infrastructure.Security;

namespace Susurri.Api.Commands.Handlers;


internal sealed class SignInHandler : ICommandHandler<SignIn>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticator _authenticator;
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;
    private readonly ITokenStorage _tokenStorage;

    public SignInHandler(IUserRepository userRepository, IAuthenticator authenticator,
        IPasswordManager passwordManager, IClock clock, ITokenStorage tokenStorage)
    {
        _userRepository = userRepository;
        _authenticator = authenticator;
        _passwordManager = passwordManager;
        _clock = clock;
        _tokenStorage = tokenStorage;
    }

    public async Task HandleAsync(SignIn command)
    {
        var user = await _userRepository.GetByUsernameAsync(command.Username);

        if (user is null)
        {
            throw new InvalidUsernameException(command.Username);
        }
        
        var isValidPassword = _passwordManager.Validate(command.Password, user.Password);

        if (!isValidPassword)
        {
            throw new InvalidPasswordException();
        }

        var jwt = _authenticator.CreateToken(user.Id, user.Username, user.Role);
        _tokenStorage.Set(jwt);
    }
}