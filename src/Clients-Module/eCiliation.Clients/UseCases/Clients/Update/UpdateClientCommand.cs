
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients.Models;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Update;

  internal record UpdateClientCommand (Guid Id, 
    string Name, 
    string Description, 
    string UserId) : IRequest<Result<ClientDetails>>;

