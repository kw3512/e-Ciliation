using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.Interfaces;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Create;
internal class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result<ClientSummary>>
{
  private readonly IClientRepository _clientRepository;

  public CreateClientCommandHandler(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;
  }

  public Task<Result<ClientSummary>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
