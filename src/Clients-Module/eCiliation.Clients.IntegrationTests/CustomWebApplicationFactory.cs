using Microsoft.AspNetCore.Mvc.Testing;

namespace eCiliation.Clients.IntegrationTests;

public class CustomWebApplicationFactory<TProgram> :
  WebApplicationFactory<TProgram> where TProgram : class
{
}

