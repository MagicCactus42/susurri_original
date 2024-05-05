using Susurri.Application.Abstractions;
using Susurri.Core.Abstractions;
using Susurri.Infrastructure.Abstractions;

namespace Susurri.Infrastructure.Commands.Handlers;


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
        // Retrieve the user from the repository using the username from the command
        var user = await _userRepository.GetByUsernameAsync(command.Username);

        if (user == null)
        {
            // User with the provided username does not exist
            // Here you can throw an Exception or handle it in any other appropriate way
            throw new Exception("User not found");
        }

        // Validate the password provided in the command with the user's password hash 
        bool isValidPassword = _passwordManager.Validate(command.Password, user.Password);

        if (!isValidPassword)
        {
            // Provided password did not match the user's password
            // Handle this case appropriately, for example by throwing an exception
            throw new Exception("Invalid password");
        }
        
        await _userRepository.AddAsync(user);
    }
}