using eCiliation.Clients.Infrastructure.Data;

namespace eCiliation.Web.Middleware;

public static class ClientsModuleMiddlewareExtensions
{
  // Using Aspire to seed db and run migrations
  // which makes this logic obsolete.
  // Should be removed after confirming new (aspire) method.
  public static void UseClientsModuleMiddleware(this WebApplication app)
  {
    using (var scope = app.Services.CreateScope())
    {
      var context = scope.ServiceProvider.GetRequiredService<ClientDbContext>();
      context.Database.EnsureCreated();
    }
  }
}
