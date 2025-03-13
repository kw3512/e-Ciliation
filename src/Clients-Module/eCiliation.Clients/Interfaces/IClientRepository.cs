using eCiliation.Clients.Domain;

namespace eCiliation.Clients.Interfaces;

internal interface IClientRepository
{
  // Commands
  Task AddAsync(Client client, CancellationToken ct);
  Task UpdateAsync(Client client, CancellationToken ct);
  Task DeactivateAsync(Client client, CancellationToken ct);
  Task SaveChangeAsync(CancellationToken ct);

  // Queries
  Task<Client?> GetByIdAsync(Guid id, CancellationToken ct);
  Task<List<Client>> ListAsync(CancellationToken ct);
}
