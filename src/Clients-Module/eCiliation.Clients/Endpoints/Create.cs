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
    Post("/client");
  }

  public override async Task HandleAsync(CreateClientRequest request, CancellationToken ct)
  {    
    var command = new CreateClientCommand(request.ClientName, request.Description);
    var results = await _mediator.Send(command, ct);

    if (!results.IsSuccess)
      await SendErrorsAsync();

    // todo: create extenstion method for mapping.
    var createClientResponse = new CreateClientResponse(
      results.Value.Id,
      results.Value.Name,
      results.Value.Description,
      results.Value.IsActive,
      results.Value.CreateStamp,
      results.Value.UpdateStamp
      );

    await SendCreatedAtAsync("/client", createClientResponse.Id, createClientResponse);
  }
}
