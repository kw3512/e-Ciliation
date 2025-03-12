using eCiliation.Clients.Domain;
using eCiliation.Clients.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace eCiliation.Clients;
public static class ClientsModuleServiceExtensions
{
  public static IServiceCollection AddClientsModuleServices(
    this IServiceCollection services,
    string connectionString,
    ILogger logger,
    List<System.Reflection.Assembly> mediatRAssemblies
    )
  {
    // Add Services
    //services.AddDbContext<ClientDbContext>(config => config.UseSqlServer(connectionString));
    // todo: add repos (scoped)

    // if using MediatR in this module, add any assemblies that contain handlers to the list
    mediatRAssemblies.Add(typeof(ClientsModuleServiceExtensions).Assembly);

    logger.Information("{Module} module services registered", "Clients");
    return services;
  }
}
