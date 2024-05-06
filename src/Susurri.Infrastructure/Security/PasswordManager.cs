using Microsoft.AspNetCore.Identity;
using Susurri.Core.Abstractions;
using Susurri.Core.Entities;

namespace Susurri.Infrastructure.Security;

internal sealed class PasswordManager(IPasswordHasher<User> passwordHasher) : IPasswordManager
{
    public string Secure(string password) => passwordHasher.HashPassword(default!, password);

    public bool Validate(string password, string securedPassword) =>
        passwordHasher.VerifyHashedPassword(default!, securedPassword, password)
            is PasswordVerificationResult.Success;
}