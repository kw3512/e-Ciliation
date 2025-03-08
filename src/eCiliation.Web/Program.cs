using eCiliation.ServiceDefaults;
using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) =>
  config.ReadFrom.Configuration(builder.Configuration));

logger.Information("Testing info message just to see the display style :)");
//builder.Services.AddFastEndpoints()
//  .SwaggerDocument();

// Aspire service
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();

// Pipeline
//app.UseFastEndpoints()
  //.UseSwaggerGen();

// Aspire pipeline
app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

