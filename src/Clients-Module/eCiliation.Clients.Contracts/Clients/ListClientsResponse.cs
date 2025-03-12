namespace eCiliation.Clients.Contracts.Clients;

public record ListClientsResponse(IEnumerable<ClientSummary> ClientSummaries);
