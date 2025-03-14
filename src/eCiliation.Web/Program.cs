using FastEndpoints.Security;

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
  .AddAuthorization()
  .SwaggerDocument();


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

