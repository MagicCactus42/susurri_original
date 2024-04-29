namespace Susurri.Client.Abstractions;

public interface IChatClient
{
    Task ReceiveMessage(string user, string message);
}