
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.Domain;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.Get;

 internal record GetClientByIdQuery(Guid Id) : IRequest<Result<Client?>>;
