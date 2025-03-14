
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.UseCases.Clients.Get;
using FastEndpoints;
using MediatR;

namespace eCiliation.Clients.Endpoints;
internal class Get : Endpoint<GetClientByIdRequest, GetClientByIdResponse>
{
  private readonly IMediator _mediator;
  public Get(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("/client/{Id}");
  }

  public override async Task HandleAsync(GetClientByIdRequest request, CancellationToken ct)
  {
    var query = new GetClientByIdQuery(request.Id);
    var results = await _mediator.Send(query, ct);

    if (!results.IsSuccess)
      await SendNotFoundAsync();

    // todo: create extenstion method for mapping.
    var getClientByIdResponse = new GetClientByIdResponse(
      results.Value!.Id,
      results.Value.Name,
      results.Value.Description,
      results.Value.IsActive,
      results.Value.CreateStamp,
      results.Value.UpdateStamp
      );

    await SendOkAsync(getClientByIdResponse);
  }
}
