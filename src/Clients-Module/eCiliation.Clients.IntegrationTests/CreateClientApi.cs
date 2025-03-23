using Ardalis.HttpClientTestExtensions;
using eCiliation.Clients.Contracts.Clients;
using Xunit;

namespace eCiliation.Clients.IntegrationTests;

public class CreateClientApi(CustomWebApplicationFactory<Program> factory) :
 IClassFixture<CustomWebApplicationFactory<Program>>
{
  // todo: Add integration tests & figure out how to test with sql database;
  // hints in ardalis's clean arch project on github.
  private readonly HttpClient _client = factory.CreateClient();

}
