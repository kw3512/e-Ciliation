
using eCiliation.SharedKernel;

namespace eCiliation.Clients.Contracts.Clients;

public record ClientDetails(Guid Id, 
  string Name, 
  string Description, 
  bool IsActive, 
  CreateStamp CreateStamp, 
  UpdateStamp? UpdateStamp);
