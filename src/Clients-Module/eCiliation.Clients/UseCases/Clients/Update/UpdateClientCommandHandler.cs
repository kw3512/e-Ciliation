
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.Interfaces;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Update;

internal class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Result<Guid>>
{
  private readonly IClientRepository _clientRepository;

  public UpdateClientCommandHandler(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;
  }

  public Task<Result<Guid>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
