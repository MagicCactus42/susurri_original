using Microsoft.AspNetCore.Authentication.JwtBearer;
using MudBlazor.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Susurri.Application.Abstractions;
using Susurri.Application.Components;
using Susurri.Application.Time;
using Susurri.Core.Abstractions;
using Susurri.Core.DAL;
using Susurri.Core.Hubs;
using Susurri.Infrastructure.Abstractions;
using Susurri.Infrastructure.Commands;
using Susurri.Infrastructure.Commands.Handlers;


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
builder.Services.AddScoped(typeof(ICommandHandler<SignUp>), typeof(SignUpHandler))
        .AddScoped<IClock, Clock>()
        .AddScoped<IPasswordManager, PasswordManager>()
        .AddScoped<ISusurriDbContext, SusurriDbContext>()
        .AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddMudServices();
builder.Services.AddServerSideBlazor().AddCircuitOptions(o => o.DetailedErrors = true);
builder.Services.AddSignalR();
builder.Services.AddPostgres();
builder.Services.AddHttpClient();
builder.Services.AddSecurity();
builder.Services.AddDbContext<SusurriDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("Host=localhost;Database=postgres;Username=postgres;Password=DtMMaNtC44i4")));


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
