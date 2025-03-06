using Ardalis.GuardClauses;
using eCiliation.SharedKernel;

namespace eCiliation.Clients.Domain;

internal class Client
{
  private readonly string _userId;

  public Guid ClientId { get; private set; } = Guid.NewGuid();
  public string Name { get; private set; } = string.Empty;
  public string? Description { get; private set; }
  public bool IsActive { get; private set; } = true;
  public DateTime CreatedOn { get; private set; } = DateTime.Now;
  public CreateStamp CreateStamp { get; private set; }
  public UpdateStamp? UpdateStamp { get; private set; }

  internal Client(Guid id, string clientName, string userId, string? description = default)
  {
    ClientId = Guard.Against.Default(id);
    Guard.Against.NullOrEmpty(clientName);
    Guard.Against.StringTooShort(clientName, ClientConstants.Min_Client_Name);
    Guard.Against.StringTooLong(clientName, ClientConstants.Max_Client_Name);
    if (!string.IsNullOrEmpty(description))
    {
      Guard.Against.StringTooShort(description, ClientConstants.Min_Client_Description);
      Guard.Against.StringTooLong(description, ClientConstants.Max_Client_Description);
    }
    Name = clientName;
    Description = description;
    _userId = Guard.Against.NullOrEmpty(userId);
    CreateStamp = new CreateStamp(_userId);
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
