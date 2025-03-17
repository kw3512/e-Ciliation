using eCiliation.MigrationService;
using eCiliation.ServiceDefaults;
using eCiliation.Clients.Infrastructure.Data;
using eCiliation.Clients.Domain;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
  .WithTracing(tracing =>
  tracing.AddSource(Worker.ActivitySourceName));

builder.AddSqlServerDbContext<ClientDbContext>(ClientConstants.CLIENT_CONNECTION_STRING);

var host = builder.Build();
host.Run();
