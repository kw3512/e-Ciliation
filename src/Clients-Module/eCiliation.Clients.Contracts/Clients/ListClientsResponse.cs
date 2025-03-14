
using eCiliation.Clients.Contracts.Clients.Models;

namespace eCiliation.Clients.Contracts.Clients;

public class ListClientsResponse
{
  public List<ClientSummary> ClientSummaryList { get; set; } = [];
}
