using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Susurri.Core.Abstractions;

namespace Susurri.Core.Hubs;

[Authorize]
public class ChatHub : Hub<IChatClient>
{
    private readonly IUserRepository UserRepository;

    public ChatHub(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public async Task SendMessage(string senderUsername,string recipientUsername, string message)
    {
        await Clients.Client(recipientUsername).ReceiveMessage(senderUsername, message);
    }

    public Task SendMessageToGroups(string user, string message, string groupName)
    {
        return Clients.Group(groupName).ReceiveMessage(user, message);
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
    public async Task AddToGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        await Clients.Group(groupName).ReceiveMessage(groupName, $"{Context.ConnectionId} has joined the group {groupName}.");
    }

    public async Task RemoveFromGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        await Clients.Group(groupName).ReceiveMessage(groupName, $"{Context.ConnectionId} has left the group {groupName}.");
    }
}