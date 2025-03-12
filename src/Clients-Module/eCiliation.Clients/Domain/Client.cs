using Ardalis.GuardClauses;
using eCiliation.SharedKernel;

namespace eCiliation.Clients.Domain;

internal class Client
{
  private readonly string _userId = string.Empty;

  public Guid Id { get; private set; } = Guid.NewGuid();
  public string Name { get; private set; } = string.Empty;
  public string Description { get; private set; } = string.Empty;
  public bool IsActive { get; private set; } = true;
  public required CreateStamp CreateStamp { get; set; } 
  public required UpdateStamp UpdateStamp { get; set; }

  public Client(Guid id, string clientName, string userId, string description)
  {
    Id = Guard.Against.Default(id);
    Guard.Against.NullOrEmpty(clientName);
    Guard.Against.StringTooShort(clientName, ClientConstants.NAME_MIN);
    Guard.Against.StringTooLong(clientName, ClientConstants.NAME_MAX);
    Guard.Against.NullOrEmpty(description);
    Guard.Against.StringTooShort(description, ClientConstants.DESCRIPTION_MIN);
    Guard.Against.StringTooLong(description, ClientConstants.DESCRIPTION_MAX);
    Name = clientName;
    Description = description;
    _userId = Guard.Against.NullOrEmpty(userId);
    CreateStamp = new CreateStamp(_userId);
  }

  private Client()
  {
    // EF 
  }

  public void Deactivate(bool setToInactive)
  {
    IsActive = Guard.Against.Deactivation(IsActive, setToInactive);
  }

  public void SetUpdateStamp()
  {
    var newUpdateStamp = new UpdateStamp(_userId);
    UpdateStamp = newUpdateStamp;
  }
}
