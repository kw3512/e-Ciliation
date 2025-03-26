var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
  .WithDataVolume()
  .WithLifetime(ContainerLifetime.Persistent)
  .AddDatabase("eCiliation");

var clientMigration = builder.AddProject<Projects.eCiliation_MigrationService>("clients-module-migration-service")
  .WithReference(sql)
  .WaitFor(sql);

builder.AddProject<Projects.eCiliation_Web>("eCiliation-api")
  .WithReference(sql)
  .WaitFor(sql)
  .WaitForCompletion(clientMigration);

builder.Build().Run();
