using System.Reflection;
using eCiliation.ServiceDefaults;
using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;
using eCiliation.Clients;
using eCiliation.SharedKernel;
using eCiliation.Web.Middleware;

// Serilog logger
var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) =>
  config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddFastEndpoints()
  .SwaggerDocument();

// todo: Review using Options pattern instead of passing all app settings items.

// Add Module Services
List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];
builder.AddClientsModuleServices(logger, mediatRAssemblies);
// Set up MediatR
builder.Services.AddMediatR(cfg =>
  cfg.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray()));
builder.Services.AddMediatRLoggingBehavior();
builder.Services.AddMediatRFluentValidationBehavior();
// Add MediatR Validator
//builder.Services.AddValidatorsFromAssemblyContaining<AddItemToCartCommandValidator>();
// Add MediatR Domain Event Dispatcher
//builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();

// Aspire service
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();


// Pipelines
app.UseFastEndpoints()
.UseSwaggerGen();

// Aspire pipeline
app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
  app.UseClientsModuleMiddleware();
}
else
{
  // Not sure this is needed but adding for now just in case Aspire needs it.  Will review more.
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  app.UseHsts();
}

app.UseHttpsRedirection();

app.Run();

