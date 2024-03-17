using Microsoft.AspNetCore.Mvc;
using Susurri.Client.Components;
using MudBlazor.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Susurri.Client.Components.Pages;
using Susurri.Client.Hubs;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

builder.Services.AddMudServices();
builder.Services.AddSignalR();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseResponseCompression();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapHub<ChatHub>("/chathub");

app.Run();
