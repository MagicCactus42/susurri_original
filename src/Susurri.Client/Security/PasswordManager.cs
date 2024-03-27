using Microsoft.AspNetCore.Identity;
using Susurri.Client.Entities;

namespace Susurri.Client.Security;

internal sealed class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<User> _passwordHasher;
    public PasswordManager(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string Secure(string password) => _passwordHasher.HashPassword(default, password);

    public bool Validate(string password, string securedPassword) =>
        _passwordHasher.VerifyHashedPassword(default, securedPassword, password)
            is PasswordVerificationResult.Success;
}