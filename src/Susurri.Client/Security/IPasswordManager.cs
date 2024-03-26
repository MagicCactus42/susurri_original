namespace Susurri.Client.Security;

public interface IPasswordManager
{
    string Secure(string password);
    bool Validate(string password, string securedPassword);
}