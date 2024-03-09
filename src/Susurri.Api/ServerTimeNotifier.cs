using Microsoft.AspNetCore.SignalR;
using Susurri.Api.Hubs;

namespace Susurri.Api;

public class ServerTimeNotifier : BackgroundService
{
    private static readonly TimeSpan Period = TimeSpan.FromSeconds(5);
    private readonly IHubContext<ChatHub, INotificationClient> _context;
    private readonly ILogger<ServerTimeNotifier> _logger;

    public ServerTimeNotifier(ILogger<ServerTimeNotifier> logger, IHubContext<ChatHub, INotificationClient> context)
    {
        _logger = logger;
        _context = context;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(Period);

        while (!stoppingToken.IsCancellationRequested &&
               await timer.WaitForNextTickAsync(stoppingToken))
        {
            var dateTime = DateTime.Now;

            _logger.LogInformation("Executing {Service} {Time}", nameof(ServerTimeNotifier), dateTime);
            await _context.Clients.User("").ReceiveNotification($"Server time = {dateTime}");
        }
    }
}