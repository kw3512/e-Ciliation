using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients.Models;
using eCiliation.Clients.Domain;
using eCiliation.Clients.Interfaces;
using MediatR;
using eCiliation.SharedKernel;

namespace eCiliation.Clients.UseCases.Clients.Create;
internal class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result<ClientDetails>>
{
  private readonly IClientRepository _clientRepository;

  public CreateClientCommandHandler(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;
  }

  public async Task<Result<ClientDetails>> Handle(CreateClientCommand request, CancellationToken ct)
  {
    Client clientToAdd = new(request.Name, request.Description, request.UserId)
    {
      CreateStamp = new CreateStamp(request.UserId),
      UpdateStamp = new UpdateStamp(null)
    };

    await _clientRepository.AddAsync(clientToAdd, ct);
    await _clientRepository.SaveChangeAsync(ct);

    var clientDetails = clientToAdd.MapClientDetails();

    return Result.Success(clientDetails);
  }
}
