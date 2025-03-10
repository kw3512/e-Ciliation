using FastEndpoints;
using eCiliation.Clients.Contracts;
using MediatR;
using eCiliation.Clients.UseCases.Create;

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

  public override async Task HandleAsync(CreateClientRequest request,
    CancellationToken cancellationToken)
  {
    // todo: add mapping and mediator logic here
    var command = new CreateClientCommand(request.clientName, request?.description);
    var result = await _mediator.Send(command);
    await SendOkAsync();
  }
}
