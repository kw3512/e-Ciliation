using eCiliation.Clients.Domain;
using eCiliation.Clients.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eCiliation.Clients.Infrastructure.Data;

internal class EfClientRepository : IClientRepository
{
  private readonly ClientDbContext _dbContext;

  public EfClientRepository(ClientDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public Task AddAsync(Client client, CancellationToken ct)
  {
    _dbContext.Add(client);
    return Task.CompletedTask;
  }

  public Task DeactivateAsync(Client client, CancellationToken ct)
  {
    _dbContext.Update(client);
    return Task.CompletedTask;
  }
  public Task UpdateAsync(Client client, CancellationToken ct)
  {
    _dbContext.Update(client);
    return Task.CompletedTask;
  }

  public async Task SaveChangeAsync(CancellationToken ct)
  {
    await _dbContext.SaveChangesAsync(ct);
  }


  public async Task<Client?> GetByIdAsync(Guid id, CancellationToken ct)
  {
    return await _dbContext.Clients.FindAsync(id, ct);
  }

  public async Task<List<Client>> ListAsync(CancellationToken ct)
  {
    return await _dbContext.Clients.Where(x => x.IsActive)
      .AsNoTracking()
      .ToListAsync(ct);
  }
}
