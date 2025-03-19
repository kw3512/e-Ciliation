
using System.Reflection;
using eCiliation.Clients.Domain;
using eCiliation.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace eCiliation.Clients.Infrastructure.Data;

public class ClientDbContext : DbContext
{
  internal DbSet<Client> Clients { get; set; }
  private readonly IConfiguration _config;

  public ClientDbContext(DbContextOptions<ClientDbContext> options, IConfiguration config): base(options)
  {
    _config = config;
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  { 
    modelBuilder.HasDefaultSchema("Clients");
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  //{
  //  /*
  //   When using this feature, it is recommended (by Microsoft) to 
  //   implement both UseSeeding and UseAsyncSeeding methods using similar 
  //   logic, even if the code using EF is asynchronous. EF Core tooling 
  //   currently relies on the synchronous version of the method 
  //   and will not seed the database correctly if the UseSeeding method 
  //   is not implemented.
  //   Hench, the reason for the duplication.
  //  */
  //  optionsBuilder
  //    .UseSqlServer(_config.GetSection(
  //      AppSettingsSectionConstants.CONNECTION_STRINGS_SECTION)
  //      [ClientConstants.CLIENT_CONNECTION_STRING])
  //    .UseSeeding((context, _) =>
  //    {
  //       context.SaveChanges();
  //    })
  //  .UseAsyncSeeding(async (context, _, ct) =>
  //  {
  //    await context.SaveChangesAsync();
  //  });
  //}

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    base.ConfigureConventions(configurationBuilder);
  }
}


//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    => optionsBuilder
//        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFDataSeeding;Trusted_Connection=True;ConnectRetryCount=0")
//        .UseSeeding((context, _) =>
//        {
//          var testBlog = context.Set<Blog>().FirstOrDefault(b => b.Url == "http://test.com");
//          if (testBlog is null)
//          {
//            context.Set<Blog>().Add(new Blog { Url = "http://test.com" });
//            context.SaveChanges();
//          }
//        })
//        .UseAsyncSeeding(async (context, _, cancellationToken) =>
//        {
//          var testBlog = await context.Set<Blog>().FirstOrDefaultAsync(b => b.Url == "http://test.com", cancellationToken);
//          if (testBlog is null)
//          {
//            context.Set<Blog>().Add(new Blog { Url = "http://test.com" });
//            await context.SaveChangesAsync(cancellationToken);
//          }
//        });
