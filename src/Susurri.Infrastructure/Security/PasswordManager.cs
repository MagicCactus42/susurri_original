using Microsoft.AspNetCore.Identity;
using Susurri.Application.Abstractions;
using Susurri.Core.Abstractions;
using Susurri.Core.Entities;

namespace Susurri.Infrastructure.Security;

internal sealed class PasswordManager(IPasswordHasher<User> passwordHasher) : IPasswordManager
{
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    public string Secure(string password) => _passwordHasher.HashPassword(default!, password);

    public bool Validate(string password, string securedPassword) =>
        _passwordHasher.VerifyHashedPassword(default!, securedPassword, password)
            is PasswordVerificationResult.Success;
}