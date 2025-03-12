using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Create;
internal record CreateClientCommand(string ClientName, string Description) : IRequest<Result<ClientSummary>>;
