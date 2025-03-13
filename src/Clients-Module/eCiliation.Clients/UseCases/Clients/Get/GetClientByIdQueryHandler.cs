
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.Interfaces;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Get;

internal class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Result<ClientSummary?>>
{
  private readonly IClientRepository _clientRepository;

  public GetClientByIdQueryHandler(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;
  }

  public Task<Result<ClientSummary?>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
