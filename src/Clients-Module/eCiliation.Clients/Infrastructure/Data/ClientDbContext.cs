
using System.Reflection;
using eCiliation.Clients.Domain;
using Microsoft.EntityFrameworkCore;

namespace eCiliation.Clients.Infrastructure.Data;

internal class ClientDbContext : DbContext
{
  internal DbSet<Client> Clients { get; set; }
  public ClientDbContext(DbContextOptions<ClientDbContext> options): base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  { 
    modelBuilder.HasDefaultSchema("Clients");
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    base.ConfigureConventions(configurationBuilder);
  }
}
