using Microsoft.AspNetCore.SignalR;
using Susurri.Core.Abstractions;
using Susurri.Core.Hubs;

namespace Susurri.Core.Services;

public class ChatService(IHubContext<ChatHub, IChatClient> hubContext)
{
    public async Task AddToGroup(string connectionId, string groupName)
    {
        await hubContext.Groups.AddToGroupAsync(connectionId, groupName);
    }

    public async Task RemoveFromGroup(string connectionId, string groupName)
    {
        await hubContext.Groups.RemoveFromGroupAsync(connectionId, groupName);
    }
}