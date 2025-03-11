
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Update;

  internal record UpdateClientCommand (ClientDto Client) : IRequest<Result<UpdateClientResponse>>;

