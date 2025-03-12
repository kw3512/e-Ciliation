
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

  public override async Task HandleAsync(UpdateClientRequest request, CancellationToken ct)
  {
    var command = new UpdateClientRequest(request.Id, request.ClientName, request.Description);

    var response = await _mediator.Send(command, ct);

    await SendNoContentAsync();
  }
}
