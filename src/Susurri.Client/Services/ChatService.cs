using Susurri.Client.Hubs;
using Microsoft.AspNetCore.SignalR;


namespace Susurri.Client.Services;

public class ChatService
{
    private readonly IHubContext<ChatHub, IChatClient> _hubContext;

    public ChatService(IHubContext<ChatHub, IChatClient> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessageToAll(string user, string message)
    {
        await _hubContext.Clients.All.ReceiveMessage(user, message);
    }

    public async Task SendMessageToCaller(string connectionId, string user, string message)
    {
        await _hubContext.Clients.Client(connectionId).ReceiveMessage(user, message);
    }

    public async Task SendMessageToGroup(string groupName, string user, string message)
    {
        await _hubContext.Clients.Group(groupName).ReceiveMessage(user, message);
    }

    public async Task AddToGroup(string connectionId, string groupName)
    {
        await _hubContext.Groups.AddToGroupAsync(connectionId, groupName);
    }

    public async Task RemoveFromGroup(string connectionId, string groupName)
    {
        await _hubContext.Groups.RemoveFromGroupAsync(connectionId, groupName);
    }
}