var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
  .WithDataVolume()
  .WithLifetime(ContainerLifetime.Persistent)
  .AddDatabase("eCiliation");

var clientMigration = builder.AddProject<Projects.eCiliation_MigrationService>("clients-module-migration-service")
  .WithReference(sql)
  .WaitFor(sql);

var api = builder.AddProject<Projects.eCiliation_Web>("eCiliation-api")
  .WithReference(sql)
  .WaitFor(sql)
  .WaitForCompletion(clientMigration);

builder.AddProject<Projects.eCiliation_Blazor_Frontend>("eciliation-blazor-frontend")
  .WaitFor(api);

builder.Build().Run();
