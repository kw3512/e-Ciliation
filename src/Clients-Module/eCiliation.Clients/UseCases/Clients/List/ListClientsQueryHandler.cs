using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.List;

internal class ListClientsQueryHandler : IRequestHandler<ListClientsQuery, Result<IEnumerable<ListClientsResponse>>>
{
  public ListClientsQueryHandler()
  {
    // todo: inject repo
  }

  public Task<Result<IEnumerable<ListClientsResponse>>> Handle(ListClientsQuery request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
