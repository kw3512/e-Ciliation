using FastEndpoints;
using MediatR;
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.UseCases.Clients.Create;

namespace eCiliation.Clients.Endpoints;
internal class Create : Endpoint<CreateClientRequest, CreateClientResponse>
{
  private readonly IMediator _mediator;
  public Create(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post("/clients");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateClientRequest request, CancellationToken ct)
  {    
    var command = new CreateClientCommand(request.Name, request.Description, request.UserId);
    var result = await _mediator.Send(command, ct);

    if (!result.IsSuccess)
    {
      await SendErrorsAsync();
      return;
    }

    var clientDetails = result.Value;
    var createClientResponse = clientDetails.MapCreateResponse();

    await SendCreatedAtAsync("/client", createClientResponse.Id, createClientResponse);
  }
}
