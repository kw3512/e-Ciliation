
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients.Models;
using eCiliation.Clients.Domain;
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

  public async Task<Result<ClientDetails>> Handle(UpdateClientCommand request, CancellationToken ct)
  {
    var existingClient = await _clientRepository.GetByIdAsync(request.Id, ct);

    if (existingClient == null)
      return Result.NotFound();

    Client clientToUpdate = new Client(request.Name, request.UserId, request.Description)
    { 
     CreateStamp = existingClient.CreateStamp
    };
    clientToUpdate.SetUpdateStamp();

    await _clientRepository.UpdateAsync(clientToUpdate, ct);
    await _clientRepository.SaveChangeAsync(ct);
    var clientDetails = clientToUpdate.MapClientDetails();

    return Result.Success(clientDetails);
  }
}
