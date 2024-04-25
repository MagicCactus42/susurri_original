using Microsoft.AspNetCore.Identity;
using Susurri.Client.Abstractions;
using Susurri.Client.Commands;
using Susurri.Client.DAL;
using Susurri.Client.Entities;
using Susurri.Client.Exceptions;
using Susurri.Client.Models;
using Susurri.Client.Repositories;
using Susurri.Client.Security;
using Susurri.Client.Services;
using Susurri.Client.Time;
using Susurri.Client.ValueObjects;

namespace Susurri.Test.Unit.Commands;

public class SignUpTests
{
    [Fact]
    public async void given_already_existing_username_signup_should_fail()
    {
        var passwordHasher = new MockPasswordHasher<User>();
        var passwordManager = new PasswordManager(passwordHasher);
        var userRepository = new UserRepository();
        var clock = new Clock();
        var userService = new UserService(_context, passwordManager);
        
        const string value = "rerer"; // already existing username
        const string pswrd = "SomePassword";
        const string userRole = "user";
        var userId = new UserId(Guid.NewGuid());
        var username = new Username(value);
        var password = _passwordManager.Secure(pswrd);
        var role = new Role(userRole);

        var user = new User(userId, username, password, role, _clock.Current());
        await _userService.SaveUser(new SignUpViewModel
        {
            Username = username,
            Password = password
        });

        await Assert.ThrowsAsync<UsernameAlreadyInUseException>(() => _userRepository.AddAsync(user));
    }

    #region Arrange

    private readonly IPasswordManager _passwordManager;
    private readonly IUserRepository _userRepository;
    private readonly IClock _clock;
    private readonly IUserService _userService;
    private readonly ISusurriDbContext _context;

    public SignUpTests()
    {
        _passwordManager = new PasswordManager(new MockPasswordHasher<User>());
        _userRepository = new UserRepository();
        _clock = new Clock();
        _context = new SusurriDbContext();
        _userService = new UserService(_context, _passwordManager);
        
    }

    #endregion

    private class MockPasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
    {
        public string HashPassword(TUser user, string password) => password;

        public PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
        {
            return hashedPassword == providedPassword ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }

}