using Susurri.Client.ValueObjects;

namespace Susurri.Client.Entities;

public class User
{
    public UserId Id { get; internal set; }
    public Username Username { get; internal set; }
    public Password Password { get; internal set; }
    public Role Role { get; internal set; }
    public DateTime CreatedAt { get; internal set; }

    public User(UserId id, Username username, Password password, Role role, DateTime createdAt)
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
        CreatedAt = createdAt;
    }

    public User()
    {
        throw new NotImplementedException();
    }
}