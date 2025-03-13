using eCiliation.Clients.Domain;
using eCiliation.Clients.Infrastructure.Data;
using eCiliation.Clients.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace eCiliation.Clients;
public static class ClientsModuleServiceExtensions
{
  public static WebApplicationBuilder AddClientsModuleServices(
    this WebApplicationBuilder builder,
    ILogger logger,
    List<System.Reflection.Assembly> mediatRAssemblies
    )
  {
    // Add Services
    builder.AddSqlServerDbContext<ClientDbContext>(ClientConstants.CLIENT_CONNECTION_STRING);
    builder.Services.AddScoped<IClientRepository, EfClientRepository>();

    // if using MediatR in this module, add any assemblies that contain handlers to the list
    mediatRAssemblies.Add(typeof(ClientsModuleServiceExtensions).Assembly);

    logger.Information("{Module} module services registered", "Clients");
    return builder;
  }
}
