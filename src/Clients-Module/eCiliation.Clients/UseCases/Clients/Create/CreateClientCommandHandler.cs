using Ardalis.Result;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Create;
internal class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result<Guid>>
{
  public CreateClientCommandHandler()
  {   
    // todo: inject repo
  }

  public Task<Result<Guid>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
