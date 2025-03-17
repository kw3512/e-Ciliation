using FastEndpoints.Security;
using Scalar.AspNetCore;

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
  .AddAuthenticationJwtBearer((opt) =>
  {
    opt.SigningKey = "ThisIsASimplePlaceholderUntil_I_AddRealSecurity";
  })
  .AddAuthorization();

// Add Module Services
List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];
builder.AddClientsModuleServices(logger, mediatRAssemblies);

// Set up MediatR
builder.AddMeiatRServices(mediatRAssemblies);

// Aspire
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();

// Middlewares
// Aspire
app.MapDefaultEndpoints();

app.UseAuthentication()
  .UseAuthorization();

app.UseFastEndpoints()
.UseSwaggerGen();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
  app.MapScalarApiReference();
  //app.UseClientsModuleMiddleware(); //Adding from Aspire Host app instead.
}
else
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  app.UseHsts();
}

//app.MapGet("/home", () => "Hello world!");
app.UseHttpsRedirection();

app.Run();

