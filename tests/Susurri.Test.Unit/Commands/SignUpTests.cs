using Microsoft.AspNetCore.Identity;
using Susurri.Client.Abstractions;
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
        string name = RandomString(8);
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
    private static Random _random = new Random();

    public static string RandomString(int length)
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