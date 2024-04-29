using Susurri.Client.Hubs;
using Microsoft.AspNetCore.SignalR;
using Susurri.Client.Abstractions;


namespace Susurri.Client.Services;

public class ChatService(IHubContext<ChatHub, IChatClient> hubContext)
{
    public async Task SendMessageToAll(string user, string message)
    {
        await hubContext.Clients.All.ReceiveMessage(user, message);
    }

    public async Task SendMessageToCaller(string connectionId, string user, string message)
    {
        await hubContext.Clients.Client(connectionId).ReceiveMessage(user, message);
    }

    public async Task SendMessageToGroup(string groupName, string user, string message)
    {
        await hubContext.Clients.Group(groupName).ReceiveMessage(user, message);
    }

    public async Task AddToGroup(string connectionId, string groupName)
    {
        await hubContext.Groups.AddToGroupAsync(connectionId, groupName);
    }

    public async Task RemoveFromGroup(string connectionId, string groupName)
    {
        await hubContext.Groups.RemoveFromGroupAsync(connectionId, groupName);
    }
}