using eCiliation.Clients.Infrastructure.Data;

namespace eCiliation.Web.Middleware;

public static class ClientsModuleMiddlewareExtensions
{
  public static WebApplication UseClientsModuleMiddleware(this WebApplication app)
  {
    using (var scope = app.Services.CreateScope())
    {
      var context = scope.ServiceProvider.GetRequiredService<ClientDbContext>();
      context.Database.EnsureCreatedAsync();
    }

    return app;
  }
}
