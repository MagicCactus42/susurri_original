using Susurri.Client.ValueObjects;

namespace Susurri.Client.Entities;

public class User
{
    public UserId Id { get; private set; }
    public Username Username { get; private set; }
    public Password Password { get; private set; }
    public Role Role { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User(UserId id, Username username, Password password, Role role, DateTime createdAt)
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
        CreatedAt = createdAt;
    }
}