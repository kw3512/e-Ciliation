
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.Contracts.Clients.Models;

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
     clientDetails.UpdateStamp
     );

    return getClientByIdResponse;
  }
}
