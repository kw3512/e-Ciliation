
using eCiliation.Clients.Contracts.Clients;
using FastEndpoints;
using MediatR;

namespace eCiliation.Clients.Endpoints;
internal class Update : Endpoint<UpdateClientRequest, UpdateClientResponse>
{
  private readonly IMediator _mediator;

  public Update(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Put("/client/{Id}");
  }

  public override async Task HandleAsync(UpdateClientRequest req, CancellationToken ct)
  {
    var clientDto = new ClientDto(req.Client.Id, req.Client.ClientName, req.Client.Description);
    var command = new UpdateClientRequest(clientDto);

    var response = await _mediator.Send(command);

    await SendNoContentAsync();
  }
}
