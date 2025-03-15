
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients.Models;
using eCiliation.Clients.Interfaces;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Get;

internal class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Result<ClientDetails>>
{
  private readonly IClientRepository _clientRepository;

  public GetClientByIdQueryHandler(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;
  }

  public async Task<Result<ClientDetails>> Handle(GetClientByIdQuery request, CancellationToken ct)
  {
    var client = await _clientRepository.GetByIdAsync(request.Id, ct);

    if (client == null)
      return Result.NotFound();

    var clientDetails = client.MapClientDetails();

    return clientDetails;  
  }
}
