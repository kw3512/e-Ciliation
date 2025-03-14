using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using eCiliation.Clients.Contracts.Clients;
using eCiliation.Clients.Domain;
using MediatR;

namespace eCiliation.Clients.UseCases.Clients.List;

internal record ListClientsQuery(): IRequest<Result<List<ClientSummary>>>;
