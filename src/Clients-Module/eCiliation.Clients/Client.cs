using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace eCiliation.Clients;

internal class Client
{
  public Guid ClientId { get; private set; } = Guid.NewGuid();
  public string ClientName { get; private set; } = string.Empty;
  public string? Description { get; private set; }
  public bool IsActive { get; private set; } = true;

  public Client(Guid id, string clientName, bool isActive, string? description = default)
  {
    ClientId = Guard.Against.Default(id);
    Guard.Against.NullOrEmpty(clientName);
    Guard.Against.StringTooShort(clientName,ClientConstants.Min_Client_Name);
    Guard.Against.StringTooLong(clientName, ClientConstants.Max_Client_Name);
    if (!string.IsNullOrEmpty(description))
    {
      Guard.Against.StringTooShort(description, ClientConstants.Min_Client_Description);
      Guard.Against.StringTooLong(description, ClientConstants.Max_Client_Description);     
    }
    ClientName = clientName;
    Description = description;
  }

  public void DeActivateClient(bool isActive)
  {
    //if(IsActive == false)
    //{

    //}

    IsActive = false;
  }
}
