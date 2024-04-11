using Susurri.Client.Abstractions;
using Susurri.Client.Commands;
using Susurri.Client.DTO;
using Susurri.Client.Queries;

namespace Susurri.Api;

public static class UsersApi
{
    private const string MeRoute = "me";
    
    public static WebApplication UseUsersApi(this WebApplication app)
    {
        app.MapGet("account/me", async (HttpContext context, IQueryHandler<GetUser, UserDto> handler) =>
        {
            var userDto = await handler.HandleAsync(new GetUser {UserId = Guid.Parse(context.User.Identity!.Name!)});
            return Results.Ok(userDto);
        }).RequireAuthorization().WithName(MeRoute);

        app.MapGet("account/{userId:guid}", async (Guid userId, IQueryHandler<GetUser, UserDto> handler) =>
        {
            var userDto = await handler.HandleAsync(new GetUser {UserId = userId});
            return userDto is null ? Results.NotFound() : Results.Ok(userDto);
        }).RequireAuthorization("is-admin");

        app.MapPost("account", async (SignUp command, ICommandHandler<SignUp> handler) =>
        {
            command = command with {UserId = Guid.NewGuid()};
            await handler.HandleAsync(command);
            return Results.CreatedAtRoute(MeRoute);
        });

        return app;
    }
}