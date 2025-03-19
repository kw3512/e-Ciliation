using System.Text.Json;
using Ardalis.HttpClientTestExtensions;
using eCiliation.Clients.Contracts.Clients;
using Xunit;

namespace eCiliation.Clients.IntegrationTests;

public class ClientsApiGet(CustomWebApplicationFactory<Program> factory) :
  IClassFixture<CustomWebApplicationFactory<Program>>
{
  // todo: Add integration tests
  private readonly HttpClient _client = factory.CreateClient();

  //[Fact]
  //public async Task MySampleIntegrationTestToUseAsAnExample()
  //{
  //  var response = await _client.GetAsync("/clients");
  //  response.EnsureSuccessStatusCode();

  //  // Example of passing back data via json serializer
  //  var responseString = await response.Content.ReadAsStringAsync();
  //  var clients = JsonSerializer
  //    .Deserialize<List<ListClientsResponse>>(responseString);

  //  Assert.True(clients!.Count > 0);
  //}

  //[Fact]
  //public async Task MySampleIntegrationTestToUseAsAnExample_WithArdalisPkgToMakeThingsMoreSimple()
  //{
  //  var clients = await _client.
  //    GetAndDeserializeAsync<List<ListClientsResponse>>("/clients");

  //  Assert.True(clients!.Count > 0);
  //}
}
