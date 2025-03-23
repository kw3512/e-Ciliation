using eCiliation.Clients.Domain;
using eCiliation.Clients.Infrastructure.Data;
using eCiliation.SharedKernel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace eCiliation.Clients.IntegrationTests;

public class CustomWebApplicationFactory<TProgram> :
  WebApplicationFactory<TProgram> where TProgram : class
{
  private readonly Guid _clientId = new Guid("3103cc30-217b-4b99-9fb6-2ebc964b345f");
  private readonly string _userId = "testUser";
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureServices(async services =>
    {
      // Remove the existing DbContext registration
      var descriptor = services.SingleOrDefault(
        d => d.ServiceType == typeof(DbContextOptions<ClientDbContext>));

      if (descriptor is not null)
      {
        services.Remove(descriptor);
      }

      // Add DbContext using an in-memory database for integration testing
      services.AddDbContext<ClientDbContext>(opts =>
      {
        opts.UseInMemoryDatabase("InMemoryDbForIntegrationTesting");
      });

      // Build the service provider
      var serviceProvider = services.BuildServiceProvider();

      // Create a scope to obtain a reference to the database context (ClientDbContext)
      using var scope = serviceProvider.CreateScope();
      var scopedServices = scope.ServiceProvider;
      var db = scopedServices.GetRequiredService<ClientDbContext>();
      var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();

      // Ensure the database is created
      db.Database.EnsureCreated();

      try
      {
        // Seed the database with test data if necessary
        await SeedDataAsync(db);
      }
      catch (Exception ex)
      {
        logger.LogError(ex, "An error occrred seeding the " +
          "databaser with the test data. Error: {Message}", ex.Message);
      }
    });
  }

  private async Task SeedDataAsync(ClientDbContext context)
  {
    
    var fakeClient = new Client(
        "Client A",
        "Client A description",
        _userId)
    {
      CreateStamp = new CreateStamp(_userId)
    };
    fakeClient.SetClientId(_clientId);

    // Add seed data here if necessary
    await context.AddAsync(fakeClient);

    await context.SaveChangesAsync();
  }
}

