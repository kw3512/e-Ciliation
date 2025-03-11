namespace eCiliation.Clients.Contracts.Clients;

public record ListClientsResponse(IEnumerable<ClientDto> Clients);
