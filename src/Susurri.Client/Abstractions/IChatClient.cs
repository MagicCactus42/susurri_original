namespace Susurri.Client.Hubs;

public interface IChatClient
{
    Task ReceiveMessage(string user, string message);
}