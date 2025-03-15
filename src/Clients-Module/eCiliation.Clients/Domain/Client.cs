using Ardalis.GuardClauses;
using eCiliation.SharedKernel;

namespace eCiliation.Clients.Domain;

internal class Client
{
  private string _userId = string.Empty;

  public Guid Id { get; private set; } = Guid.NewGuid();
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public bool IsActive { get; private set; } = true;
  public required CreateStamp CreateStamp { get; init; } 
  public required UpdateStamp UpdateStamp { get; set; }

  public Client(string clientName, string description, string userId) 
  {
    Guard.Against.NullOrEmpty(clientName);
    Guard.Against.StringTooShort(clientName, ClientConstants.NAME_MIN);
    Guard.Against.StringTooLong(clientName, ClientConstants.NAME_MAX);
    Guard.Against.NullOrEmpty(description);
    Guard.Against.StringTooShort(description, ClientConstants.DESCRIPTION_MIN);
    Guard.Against.StringTooLong(description, ClientConstants.DESCRIPTION_MAX);
    Name = clientName;
    Description = description;
    SetUserId(userId);
    CreateStamp = new CreateStamp(_userId);
  }

  private Client()
  {
    // EF 
  }

  public void Deactivate()
  {
    IsActive = Guard.Against.Deactivation(IsActive);
  }

  public void SetUpdateStamp()
  {
    var newUpdateStamp = new UpdateStamp(_userId);
    UpdateStamp = newUpdateStamp;
  }

  public void SetUserId(string userId)
  {
    _userId = Guard.Against.NullOrEmpty(userId);
  }
}
