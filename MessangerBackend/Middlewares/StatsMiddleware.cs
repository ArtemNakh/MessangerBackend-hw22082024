using MessangerBackend.Core.Interfaces;
using MessangerBackend.Storage;
using Microsoft.Identity.Client;

namespace MessangerBackend.Middlewares;

public class StatsMiddleware
{
    private readonly RequestDelegate _next;

    public StatsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext ctx)
    {
        var userService = ctx.RequestServices.GetRequiredService<IUserService>();
        var path = ctx.Request.Path.Value;
        if (path != null && path.StartsWith("/api/users/search/"))
        {
            var name = path.Replace("/api/users/search/", "");

            await userService.AddStats(name);
        }
        await _next.Invoke(ctx);
    }
}