
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.UseCases.Clients.Update;
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
    var command = new UpdateClientCommand(request.Id, request.Name, request.Description, request.UserId);
    var result = await _mediator.Send(command, ct);

    var clientDetails = result.Value;
    var updateClientReponse = clientDetails.MapUpdateResponse();

    await SendAsync(updateClientReponse);
  }
}
