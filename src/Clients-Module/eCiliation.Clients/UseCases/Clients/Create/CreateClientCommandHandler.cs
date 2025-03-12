using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Create;
internal class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result<ClientSummary>>
{
  public CreateClientCommandHandler()
  {   
    // todo: inject repo
  }

  public Task<Result<ClientSummary>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
