
using Ardalis.Result;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Deactivate;

internal class DeactivateClientCommandHandler : IRequestHandler<DeactivateClientCommand, Result>
{
  public DeactivateClientCommandHandler()
  {
    // todo: inject repo
  }

  public Task<Result> Handle(DeactivateClientCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
