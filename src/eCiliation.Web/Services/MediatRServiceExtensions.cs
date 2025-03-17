using eCiliation.SharedKernel;

namespace eCiliation.Web.Services;

public static class MediatRServiceExtensions
{
  public static void AddMeiatRServices(
    this WebApplicationBuilder builder,
    List<Assembly> mediatRAssemblies)
  {
    // Set up MediatR
    builder.Services.AddMediatR(cfg =>
      cfg.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray()));
    builder.Services.AddMediatRLoggingBehavior();
    builder.Services.AddMediatRFluentValidationBehavior();
    
    // Add MediatR Validator
    //builder.Services.AddValidatorsFromAssemblyContaining<AddItemToCartCommandValidator>();
    
    // Add MediatR Domain Event Dispatcher
    //builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
  }
}
