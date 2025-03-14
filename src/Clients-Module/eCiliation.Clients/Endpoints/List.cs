
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.UseCases.Clients.List;
using FastEndpoints;
using MediatR;

namespace eCiliation.Clients.Endpoints;
internal class List : EndpointWithoutRequest<ListClientsResponse>
{
  private readonly IMediator _mediator;
  public List(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("/clients");
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var result = await _mediator.Send(new ListClientsQuery(), ct);

    var listClientsResponse = new ListClientsResponse()
    {
      ClientSummaryList = result.Value
    };

    await SendOkAsync(listClientsResponse);
  }
}
