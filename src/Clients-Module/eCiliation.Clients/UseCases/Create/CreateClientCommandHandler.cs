using Ardalis.Result;
using MediatR;

namespace eCiliation.Clients.UseCases.Create;
internal class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result>
{
  public CreateClientCommandHandler()
  {   
    // todo: inject repo
  }

  public Task<Result> Handle(CreateClientCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
