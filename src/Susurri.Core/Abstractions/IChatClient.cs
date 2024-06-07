namespace Susurri.Core.Abstractions;

public interface IChatClient
{
    Task ReceiveMessage(string sender, string recipient, string message);
}