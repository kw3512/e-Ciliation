
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
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetClientByIdRequest request, CancellationToken ct)
  {
    var query = new GetClientByIdQuery(request.Id);
    var result = await _mediator.Send(query, ct);

    if (!result.IsSuccess)
      await SendNotFoundAsync();

    var clientDetails = result.Value;
    var response = clientDetails.MapGetByIdResponse();

    await SendOkAsync(response);
  }
}
