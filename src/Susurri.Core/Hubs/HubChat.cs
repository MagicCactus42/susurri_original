using System.Security.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Susurri.Core.Abstractions;

namespace Susurri.Core.Hubs;

[Authorize]
public class ChatHub : Hub<IChatClient>
{
    public async Task SendMessage(string senderUsername,string recipientUsername, string message)
    {
        await Clients.Client(recipientUsername).ReceiveMessage(senderUsername, message);
    }

    public Task SendMessageToGroups(string senderUsername, string message, string groupName)
    {
        return Clients.Group(groupName).ReceiveMessage(senderUsername, message);
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
    public async Task AddToGroup(string username, string groupName)
    {
        var name = Context.User.Identity.Name;

        if (string.IsNullOrWhiteSpace(name) || name != username)
            throw new InvalidCredentialException();
        
        await Groups.AddToGroupAsync(name, groupName);
        await Clients.Group(groupName).ReceiveMessage(groupName, $"{name} has joined the group {groupName}.");
    }

    public async Task RemoveFromGroup(string username, string groupName)
    {
        var name = Context.User.Identity.Name;

        if (string.IsNullOrWhiteSpace(name) || name != username)
            throw new InvalidCredentialException();
        
        await Groups.RemoveFromGroupAsync(name, groupName);
        await Clients.Group(groupName).ReceiveMessage(groupName, $"{name} has left the group {groupName}.");
    }
}