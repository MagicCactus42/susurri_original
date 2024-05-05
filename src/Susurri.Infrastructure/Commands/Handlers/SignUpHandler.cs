using Susurri.Application.Abstractions;
using Susurri.Infrastructure.Abstractions;
using Susurri.Core.Abstractions;
using Susurri.Core.Entities;
using Susurri.Core.Exceptions;
using Susurri.Core.ValueObjects;

namespace Susurri.Infrastructure.Commands.Handlers;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;
    private readonly IUserRepository _userRepository;
    
    public SignUpHandler(IPasswordManager passwordManager, IClock clock, IUserRepository userRepository)
    {
        _passwordManager = passwordManager;
        _clock = clock;
        _userRepository = userRepository;
    }
    
    
    public async Task HandleAsync(SignUp command)
    {
        // validate input
        var userId = new UserId(command.UserId);
        var username = new Username(command.Username);
        var password = new Password(command.Password);
        var role = string.IsNullOrWhiteSpace(command.Role) ? Role.User() : new Role(command.Role);
        // validate if user already exist
        if (await _userRepository.GetByUsernameAsync(username) is not null)
        {
            throw new UsernameAlreadyInUseException(username);
        }
        // create the user
        var securePassword = _passwordManager.Secure(password);
        var user = new User(userId, username, securePassword, role,
            _clock.Current());
        // save to db
        await _userRepository.AddAsync(user);
    }
}