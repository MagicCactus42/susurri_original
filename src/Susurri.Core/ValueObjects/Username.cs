using Susurri.Core.Exceptions;

namespace Susurri.Core.ValueObjects;

public sealed record Username
{
    public string Value { get; }
        
    public Username(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 12 or < 3 )
        {     
            throw new InvalidUsernameException(value);
        }
            
        Value = value;
    }

    public static implicit operator Username(string value) => new(value);

    public static implicit operator string(Username value) => value.Value;

    public override string ToString() => Value;
}