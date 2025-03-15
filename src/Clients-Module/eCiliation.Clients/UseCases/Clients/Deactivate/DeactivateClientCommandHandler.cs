
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

  public async Task<Result> Handle(DeactivateClientCommand request, CancellationToken ct)
  {
    var clientToDeactivate = await _clientRepository.GetByIdAsync(request.Id, ct);

    if (clientToDeactivate == null)
      return Result.NotFound();

    clientToDeactivate!.Deactivate();
    clientToDeactivate.SetUserId(request.UserId);
    clientToDeactivate.SetUpdateStamp();

    await _clientRepository.UpdateAsync(clientToDeactivate, ct);
    await _clientRepository.SaveChangeAsync(ct);

    return Result.Success();
  }
}
