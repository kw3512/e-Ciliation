using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sqlServer-2022")
  .WithDataVolume()
  .WithLifetime(ContainerLifetime.Persistent)
  .AddDatabase("eCiliation");

builder.AddProject<Projects.eCiliation_Web>("eciliation-web")
  .WithReference(sql)
  .WaitFor(sql);

builder.Build().Run();
