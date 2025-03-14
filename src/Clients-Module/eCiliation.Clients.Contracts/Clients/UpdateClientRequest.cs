
namespace eCiliation.Clients.Contracts.Clients;
public record UpdateClientRequest(Guid Id, string Name, string Description, string UserId);
