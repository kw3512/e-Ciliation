
using Ardalis.Result;
using eCiliation.Clients.Interfaces;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Deactivate;

internal class DeactivateClientCommandHandler : IRequestHandler<DeactivateClientCommand, Result>
{
  private readonly IClientRepository _clientRepository;

  public DeactivateClientCommandHandler(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;
  }

  public Task<Result> Handle(DeactivateClientCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
