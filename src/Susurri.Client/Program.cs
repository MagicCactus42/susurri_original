using Microsoft.AspNetCore.Authentication.JwtBearer;
using Susurri.Client.Components;
using MudBlazor.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Susurri.Client.Hubs;
using Microsoft.IdentityModel.Tokens;
using Susurri.Client.Abstractions;
using Susurri.Client.Commands;
using Susurri.Client.Commands.Handlers;
using Susurri.Client.DAL;
using Susurri.Client.Security;
using Susurri.Client.Services;
using Susurri.Client.Time;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
    // Tu wrzucic parametry po dodaniu miejsca na tokeny
    // https://www.youtube.com/watch?v=mgeuh8k3I4g  9:48 koniec
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
builder.Services.AddScoped(typeof(ICommandHandler<SignUp>), typeof(SignUpHandler));
builder.Services.AddScoped<IClock, Clock>();
builder.Services.AddScoped<IPasswordManager, PasswordManager>();
builder.Services.AddTransient<UserService>();
builder.Services.AddMudServices();
builder.Services.AddSignalR();
builder.Services.AddPostgres();
builder.Services.AddHttpClient();
builder.Services.AddSecurity();
builder.Services.AddDbContext<SusurriDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapHub<ChatHub>("/chathub");

app.Run();
