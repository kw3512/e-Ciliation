
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients.Models;
using eCiliation.Clients.Interfaces;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.List;

internal class ListClientsQueryHandler : IRequestHandler<ListClientsQuery, Result<List<ClientSummary>>>
{
  private readonly IClientRepository _clientRepository;

  public ListClientsQueryHandler(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;
  }

  public async Task<Result<List<ClientSummary>>> Handle(ListClientsQuery request, CancellationToken ct)
  {
    var clients = await _clientRepository.ListAsync(ct);

    if (clients == null)
      return Result.NotFound();

    var clientSummaries = clients.MapClientSummaries();

    return clientSummaries;
  }
}
