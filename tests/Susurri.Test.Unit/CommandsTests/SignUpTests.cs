using Microsoft.AspNetCore.Identity;
using Susurri.Api.Repositories;
using Susurri.Application.Abstractions;
using Susurri.Core.Abstractions;
using Susurri.Core.DAL;
using Susurri.Core.Entities;
using Susurri.Core.Exceptions;
using Susurri.Core.Models;
using Susurri.Core.Services;
using Susurri.Core.ValueObjects;
using Susurri.Infrastructure.Security;
using Susurri.Infrastructure.Time;

namespace Susurri.Test.Unit.CommandsTests;

public class SignUpTests
{
    [Fact]
    public async void given_already_existing_username_signup_should_fail()
    {
        const string value = "rerer"; // already existing username
        const string pswrd = "SomePassword";
        var username = new Username(value);
        var password = _passwordManager.Secure(pswrd);
        
        await Assert.ThrowsAsync<UsernameAlreadyInUseException>(async () =>
        {
            await _userService.SaveUser(new SignUpViewModel
            {
                Username = username,
                Password = password
            });
        });
    }

    [Fact]
    public async void given_too_short_password_should_fail()
    {
        const string haslo = "123";
        var name = RandomString(8);
        var password = _passwordManager.Secure(haslo);
        
        await Assert.ThrowsAsync<InvalidPasswordException>(async () =>
        {
            await _userService.SaveUser(new SignUpViewModel
            {
                Username = name,
                Password = password
            });
        });
        
    }

    [Fact]
    public async void given_too_short_username_should_fail()
    {
        const string name = "op";
        var haslo = RandomString(10);
        var password = _passwordManager.Secure(haslo);

        await Assert.ThrowsAsync<InvalidUsernameException>(async () =>
        {
            await _userService.SaveUser(new SignUpViewModel
            {
                Username = name,
                Password = password
            });
        });
    }

    [Fact]
    public async void given_too_long_username_should_fail()
    {
        const string name = "Username123123";
        var haslo = RandomString(10);
        var password = _passwordManager.Secure(haslo);

        await Assert.ThrowsAsync<InvalidUsernameException>(async () =>
            await _userService.SaveUser(new SignUpViewModel
            {
                Username = name,
                Password = password
            }));
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
    private static Random _random = new();

    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
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