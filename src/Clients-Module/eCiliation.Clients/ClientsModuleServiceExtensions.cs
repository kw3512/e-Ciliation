using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace eCiliation.Clients;
public static class ClientsModuleServiceExtensions
{
  public static IServiceCollection AddClientsModuleServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger,
    List<System.Reflection.Assembly> mediatRAssemblies
    )
  {
    // todo: add db contexts
    // todo: add repos (scoped)

    // if using MediatR in this module, add any assemblies that contain handlers to the list
    mediatRAssemblies.Add(typeof(ClientsModuleServiceExtensions).Assembly);

    logger.Information("{Module} module services registered", "Clients");
    return services;
  }
}
