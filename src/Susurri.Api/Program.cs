using Microsoft.AspNetCore.Authentication.JwtBearer;
using MudBlazor;
using MudBlazor.Services;
using Susurri.Api;
using Susurri.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();
    
builder.Services.AddSignalR();
builder.Services.AddHostedService<ServerTimeNotifier>();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddMudServices();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IDialogService>();
builder.Services.AddScoped<MudDialogProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) app.UseResponseCompression();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();
app.UseHttpsRedirection();

app.MapHub<ChatHub>("/Chat");


app.Run();