
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients.Models;
using eCiliation.Clients.Interfaces;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Update;

internal class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Result<ClientDetails>>
{
  private readonly IClientRepository _clientRepository;

  public UpdateClientCommandHandler(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;
  }

  public Task<Result<ClientDetails>> Handle(UpdateClientCommand request, CancellationToken ct)
  {
    throw new NotImplementedException();
  }
}
