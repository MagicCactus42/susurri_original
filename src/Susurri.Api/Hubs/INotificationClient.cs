namespace Susurri.Api.Hubs;

public interface INotificationClient
{
    Task ReceiveNotification(string message);
}