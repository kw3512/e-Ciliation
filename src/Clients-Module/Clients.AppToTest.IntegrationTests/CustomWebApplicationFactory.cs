using Microsoft.AspNetCore.Mvc.Testing;

namespace Clients.AppToTest.IntegrationTests;

public class CustomWebApplicationFactory<TProgram>:
  WebApplicationFactory<TProgram> where TProgram : class
{

}
