
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Get;

 internal record GetClientByIdQuery(Guid Id) : IRequest<Result<GetClientByIdResponse?>>;
