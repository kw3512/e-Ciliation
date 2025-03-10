using Ardalis.Result;
using MediatR;

namespace eCiliation.Clients.UseCases.Create;
internal record CreateClientCommand(string clientName, string? description) : IRequest<Result>;
