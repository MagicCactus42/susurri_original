using Microsoft.AspNetCore.SignalR;
using Susurri.Client.Abstractions;

namespace Susurri.Client.Hubs;


public class ChatHub : Hub<IChatClient>
{
    
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.ReceiveMessage(user, message);
    }

    public Task SendMessageToCaller(string user, string message)
    {
        return Clients.Caller.ReceiveMessage(user, message);
    }

    public Task SendMessageToGroups(string user, string message)
    {
        return Clients.Group("testGroup").ReceiveMessage(user, message);
    }

    public override async Task OnConnectedAsync()
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await base.OnDisconnectedAsync(exception);
    }
    public async Task AddToGroup(string testGroup)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, testGroup);

        await Clients.Group(testGroup).ReceiveMessage(testGroup, $"{Context.ConnectionId} has joined the group {testGroup}.");
    }

    public async Task RemoveFromGroup(string testGroup)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, testGroup);

        await Clients.Group(testGroup).ReceiveMessage(testGroup, $"{Context.ConnectionId} has left the group {testGroup}.");
    }
}