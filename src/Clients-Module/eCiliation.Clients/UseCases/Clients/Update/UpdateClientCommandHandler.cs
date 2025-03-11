
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Update;

internal class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Result<UpdateClientResponse>>
{
  public UpdateClientCommandHandler()
  {
    // todo: inject repo
  }
  public Task<Result<UpdateClientResponse>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
