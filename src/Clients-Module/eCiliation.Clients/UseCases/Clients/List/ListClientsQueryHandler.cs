using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.Interfaces;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.List;

internal class ListClientsQueryHandler : IRequestHandler<ListClientsQuery, Result<IEnumerable<ClientSummary>>>
{
  private readonly IClientRepository _clientRepository;

  public ListClientsQueryHandler(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;
  }

  public Task<Result<IEnumerable<ClientSummary>>> Handle(ListClientsQuery request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
