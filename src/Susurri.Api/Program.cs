using MudBlazor.Services;
using Susurri.Client.DAL;
using Susurri.Core.DAL;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();
    
builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMudServices();
builder.Services.AddPostgres();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) app.UseResponseCompression();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();
app.UseHttpsRedirection();



app.Run();