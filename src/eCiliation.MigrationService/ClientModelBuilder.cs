using eCiliation.Clients.Domain;
using eCiliation.SharedKernel;

namespace eCiliation.MigrationService;

public static class ClientModelBuilder
{
  public static List<Client> GetClients()
  {
    var clients = new List<Client>() {
      new Client("Client A", "Client A description...", "testUser")
      {
        CreateStamp = new CreateStamp("testUser"),
        UpdateStamp = new()
      },
      new Client("Client B", "Client B description...", "testUser")
      {
        CreateStamp = new CreateStamp("testUser"),
        UpdateStamp = new UpdateStamp("testUser")
      },
    }.OrderBy(c => c.Name).ToList();

    return clients;
  }
}
