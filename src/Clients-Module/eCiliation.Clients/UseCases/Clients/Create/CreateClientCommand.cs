using Ardalis.Result;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Create;
internal record CreateClientCommand(string ClientName, string? Description) : IRequest<Result<Guid>>;
