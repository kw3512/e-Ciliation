
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.Contracts.Clients.Models;
using eCiliation.Clients.Domain;

namespace eCiliation.Clients;

internal static class ClientsModuleMapperExtensions
{
  public static GetClientByIdResponse MapGetByIdResponse(
    this ClientDetails clientDetails)
  {
    var getClientByIdResponse = new GetClientByIdResponse(
     clientDetails.Id,
     clientDetails.Name,
     clientDetails.Description,
     clientDetails.IsActive,
     clientDetails.CreateStamp,
     clientDetails.UpdateStamp);

    return getClientByIdResponse;
  }

  public static CreateClientResponse MapCreateResponse(
    this ClientDetails clientDetails)
  {
    var createClientResponse = new CreateClientResponse(
     clientDetails.Id,
     clientDetails.Name,
     clientDetails.Description,
     clientDetails.IsActive,
     clientDetails.CreateStamp,
     clientDetails.UpdateStamp);

    return createClientResponse;
  }

  public static UpdateClientResponse MapUpdateResponse(
    this ClientDetails clientDetails)
  {
    var updateClientResponse = new UpdateClientResponse(
     clientDetails.Id,
     clientDetails.Name,
     clientDetails.Description,
     clientDetails.IsActive,
     clientDetails.CreateStamp,
     clientDetails.UpdateStamp);

    return updateClientResponse;
  }

  public static ClientDetails MapClientDetails(
    this Client client)
  {
    var cd = new ClientDetails(
     client.Id,
     client.Name,
     client.Description,
     client.IsActive,
     client.CreateStamp,
     client.UpdateStamp);

    return cd;
  }

  public static List<ClientSummary> MapClientSummaries(
    this IEnumerable<Client> clients)
  {
    return clients.Select(c => new ClientSummary(
     c.Id,
     c.Name,
     c.Description
     )).ToList();
  }
}
