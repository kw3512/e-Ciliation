
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
    var command = new UpdateClientCommand(request.Id, request.ClientName, request.Description);
    var results = await _mediator.Send(command, ct);

    // todo: create extenstion method for mapping.
    var updateClientResponse = new UpdateClientResponse(
      results.Value.Id,
      results.Value.Name,
      results.Value.Description,
      results.Value.IsActive,
      results.Value.CreateStamp,
      results.Value.UpdateStamp
      );

    await SendAsync(updateClientResponse);
  }
}
