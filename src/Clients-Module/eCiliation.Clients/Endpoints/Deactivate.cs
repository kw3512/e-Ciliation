
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.UseCases.Clients.Deactivate;
using FastEndpoints;
using MediatR;

namespace eCiliation.Clients.Endpoints;
internal class Deactivate : Endpoint<DeactivateClientRequest>
{
  private readonly IMediator _mediator;
  public Deactivate(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Put("/client/{id}/deactivate");
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeactivateClientRequest request, CancellationToken ct)
  {
    var command = new DeactivateClientCommand(request.Id);
    var result = await _mediator.Send(command, ct);

    if (!result.IsSuccess)
      await SendNotFoundAsync();

    await SendOkAsync();
  }
}
