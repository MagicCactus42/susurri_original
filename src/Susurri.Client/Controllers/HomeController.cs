using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Susurri.Client.Hubs;

namespace Susurri.Client.Controllers;

public class HomeController : Controller
{
    public IHubContext<ChatHub, IChatClient> _strongChatHubContext { get; }

    public HomeController(IHubContext<ChatHub, IChatClient> chatHubContext)
    {
        _strongChatHubContext = chatHubContext;
    }

    public async Task SendMessage(string user, string message)
    {
        await _strongChatHubContext.Clients.All.ReceiveMessage(user, message);
    }
}