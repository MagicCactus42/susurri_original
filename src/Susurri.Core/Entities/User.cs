using Susurri.Core.ValueObjects;

namespace Susurri.Core.Entities;

public class User
{
    public UserId Id { get; internal init; }
    public Username Username { get; internal init; }
    public Password Password { get; internal init; }
    public Role Role { get; internal init; }
    public DateTime CreatedAt { get; internal init; }

    public User(UserId id, Username username, Password password, Role role, DateTime createdAt)
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
        CreatedAt = createdAt;
    }
    
}
