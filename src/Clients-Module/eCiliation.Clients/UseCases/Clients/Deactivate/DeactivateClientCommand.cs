
using Ardalis.Result;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Deactivate;

internal record DeactivateClientCommand(Guid Id, string UserId) : IRequest<Result>;
