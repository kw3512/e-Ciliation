
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Update;

  internal record UpdateClientCommand (Guid Id, string ClientName, string Description) : IRequest<Result<ClientDetails>>;

