
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Get;

internal class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Result<ClientSummary?>>
{
  public GetClientByIdQueryHandler()
  {
    // todo: inject repo
  }
  public Task<Result<ClientSummary?>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
