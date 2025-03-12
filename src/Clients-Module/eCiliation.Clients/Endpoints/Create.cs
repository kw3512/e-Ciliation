using FastEndpoints;
using MediatR;
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.UseCases.Clients.Create;

namespace eCiliation.Clients.Endpoints;
internal class Create : Endpoint<CreateClientRequest>
{
  private readonly IMediator _mediator;
  public Create(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post("/client");
  }

  public override async Task HandleAsync(CreateClientRequest request, CancellationToken ct)
  {
    // todo: add mapping and mediator logic here
    var command = new CreateClientCommand(request.ClientName, request.Description);
    var result = await _mediator.Send(command, ct);
    await SendOkAsync();
  }
}
