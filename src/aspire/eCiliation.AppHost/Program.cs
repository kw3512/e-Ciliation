var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sqlServer2022")
  .WithDataVolume()
  .WithLifetime(ContainerLifetime.Persistent)
  .AddDatabase("eCiliation");

builder.AddProject<Projects.eCiliation_Web>("eciliation-web")
  .WithReference(sql)
  .WaitFor(sql);

builder.AddProject<Projects.eCiliation_MigrationService>("clients-module-migration-service")
  .WithReference(sql)
  .WaitFor(sql);

builder.Build().Run();
