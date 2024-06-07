using System.Security.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Susurri.Core.Abstractions;
using Susurri.Core.Entities;

namespace Susurri.Core.Hubs;

[Authorize]
public class ChatHub : Hub<IChatClient>
{
    private readonly ISusurriDbContext _context;

    public ChatHub(ISusurriDbContext context)
    {
        _context = context;
    }

    public async Task SendMessage(string sender, string recipient, string message)
    {
        var chatMessage = new ChatMessage
        {
            SenderUsername = sender,
            RecipientUsername = recipient,
            Content = message
        };

        _context.ChatMessages.Add(chatMessage);
        await _context.SaveChangesAsync();

        await Clients.User(recipient).ReceiveMessage( sender, recipient, message);
        await Clients.User(sender).ReceiveMessage(sender, recipient, message);
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
}