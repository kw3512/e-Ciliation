using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients.Models;
using eCiliation.Clients.Domain;
using eCiliation.Clients.Interfaces;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Create;
internal class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result<ClientDetails>>
{
  private readonly IClientRepository _clientRepository;

  public CreateClientCommandHandler(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;
  }

  public Task<Result<ClientDetails>> Handle(CreateClientCommand request, CancellationToken ct)
  {
    throw new NotImplementedException();
  }
}
