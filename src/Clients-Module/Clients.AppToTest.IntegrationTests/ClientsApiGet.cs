using System.Text.Json;
//using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Clients.AppToTest.IntegrationTests;

public class ClientsApiGet(CustomWebApplicationFactory<Program> factory):
  IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task MySampleIntegrationTestToUseAsAnExample()
  {
    var response = await _client.GetAsync("/weatherforecast");
    response.EnsureSuccessStatusCode();

    // Example of passing back data via json serializer
    var responseString = await response.Content.ReadAsStringAsync();
    var forecasts = JsonSerializer
      .Deserialize<List<WeatherForecast>>(responseString);

    Assert.Equal(5, forecasts!.Count);
  }
}
