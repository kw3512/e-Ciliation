
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients.Models;
using eCiliation.Clients.Domain;
using eCiliation.Clients.Interfaces;
using eCiliation.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;

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
    var clientToUpdate = await _clientRepository.GetByIdAsync(request.Id, ct);

    if (clientToUpdate == null)
    {
      return Result.NotFound();
    }

    clientToUpdate.Name = request.Name;
    clientToUpdate.Description = request.Description;
    clientToUpdate.SetUserId(request.UserId);
    clientToUpdate.SetUpdateStamp();

    await _clientRepository.UpdateAsync(clientToUpdate, ct);
    await _clientRepository.SaveChangeAsync(ct);

    var clientDetails = clientToUpdate.MapClientDetails();

    return Result.Success(clientDetails);
  }
}
