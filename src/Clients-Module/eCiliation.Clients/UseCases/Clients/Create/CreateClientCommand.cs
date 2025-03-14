using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.Domain;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Create;
internal record CreateClientCommand(string ClientName, string Description) : IRequest<Result<Client>>;
