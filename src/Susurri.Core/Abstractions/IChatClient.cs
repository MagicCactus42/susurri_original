namespace Susurri.Core.Abstractions;

public interface IChatClient
{
    Task ReceiveMessage(string user, string message);
}