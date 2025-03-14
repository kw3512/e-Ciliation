
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
    var client = await _clientRepository.GetByIdAsync(request.Id, ct);

    if (client == null)
      return Result.NotFound();

    client!.Deactivate();
    client.SetUpdateStamp();

    await _clientRepository.UpdateAsync(client, ct);
    await _clientRepository.SaveChangeAsync(ct);

    return Result.Success();
  }
}
