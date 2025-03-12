
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Update;

internal class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Result<Guid>>
{
  public UpdateClientCommandHandler()
  {
    // todo: inject repo
  }
  public Task<Result<Guid>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
