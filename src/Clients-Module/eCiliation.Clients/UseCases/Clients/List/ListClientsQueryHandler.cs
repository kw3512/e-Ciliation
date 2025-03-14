
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.Domain;
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

  public Task<Result<List<ClientSummary>>> Handle(ListClientsQuery request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
