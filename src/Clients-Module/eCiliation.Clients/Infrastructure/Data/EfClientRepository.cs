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

  public Task SaveChangeAsync(CancellationToken ct)
  {
     return _dbContext.SaveChangesAsync(ct);
  }


  public Task<Client?> GetByIdAsync(Guid id, CancellationToken ct)
  {
    return _dbContext.Clients.SingleOrDefaultAsync(c => c.Id == id);
  }

  public Task<List<Client>> ListAsync(CancellationToken ct)
  {
    return _dbContext.Clients.Where(x => x.IsActive)
      .AsNoTracking()
      .ToListAsync(ct);
  }
}
