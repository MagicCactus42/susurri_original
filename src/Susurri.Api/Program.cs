using Microsoft.AspNetCore.ResponseCompression;
using Susurri.Api.Repositories;
using Susurri.Application;
using Susurri.Application.Abstractions;
using Susurri.Application.Components;
using Susurri.Core;
using Susurri.Core.Hubs;
using Susurri.Infrastructure;

namespace Susurri.Api;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();

        builder.Services.AddControllers();

// Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services
            .AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "application/octet-stream" });
        });

        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddCors();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddCore()
            .AddInfrastructure()
            .AddApplication();

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment()) app.UseResponseCompression();

        app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAntiforgery();
        app.UseResponseCompression();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();
        app.MapHub<ChatHub>("/chathub");

        await app.RunAsync();
    }
}