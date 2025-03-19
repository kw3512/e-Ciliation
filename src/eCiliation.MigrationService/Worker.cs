using System.Diagnostics;
using eCiliation.Clients.Infrastructure.Data;
using eCiliation.Clients.Domain;
using eCiliation.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace eCiliation.MigrationService;

public class Worker(
  IServiceProvider serviceProvider,
    IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
{
  public const string ActivitySourceName = "Clients Module Migrations";
  private static readonly ActivitySource s_activitySource = new(ActivitySourceName);

  protected override async Task ExecuteAsync(CancellationToken cancellationToken)
  {
    using var activity = s_activitySource.StartActivity("Migrating Clients database", ActivityKind.Client);

    try
    {
      using var scope = serviceProvider.CreateScope();
      var dbContext = scope.ServiceProvider.GetRequiredService<ClientDbContext>();

      await RunMigrationAsync(dbContext, cancellationToken);
      // todo: Make this call meet the following 2 conditions:
      // 1. ONLY run when in development environment
      // 2. ONLY run when db does NOT have data
      await SeedDataAsync(dbContext, cancellationToken);
    }
    catch (Exception ex)
    {
      activity?.AddException(ex);
      throw;
    }

    hostApplicationLifetime.StopApplication();
  }

  private static async Task RunMigrationAsync(ClientDbContext dbContext, CancellationToken cancellationToken)
  {
    var strategy = dbContext.Database.CreateExecutionStrategy();
    await strategy.ExecuteAsync(async () =>
    {
      // Run migration in a transaction to avoid partial migration if it fails.
      await dbContext.Database.MigrateAsync(cancellationToken);
    });
  }

  private static async Task SeedDataAsync(ClientDbContext dbContext, CancellationToken cancellationToken)
  {
    var clients = new List<Client>() {
      new Client("Client A", "Client A description...", "testUser")
      {
        CreateStamp = new CreateStamp("testUser"),
        UpdateStamp = new()
      },
      new Client("Client B", "Client B description...", "testUser")
      {
        CreateStamp = new CreateStamp("testUser"),
        UpdateStamp = new UpdateStamp("testUser")
      },
    }.OrderBy(c => c.Name).ToList();

    var strategy = dbContext.Database.CreateExecutionStrategy();
    await strategy.ExecuteAsync(async () =>
    {
      // Seed the database
      await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
      await dbContext.AddRangeAsync(clients, cancellationToken);
      await dbContext.SaveChangesAsync(cancellationToken);
      await transaction.CommitAsync(cancellationToken);
    });
  }
}
