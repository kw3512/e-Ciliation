using Ardalis.GuardClauses;

namespace eCiliation.SharedKernel;
public class CreateStamp
{
  public DateTime CreatedOn { get; private set; } = DateTime.Now;
  public string CreatedBy { get; private set; }

  public CreateStamp(string createdBy)
  {
    CreatedBy = Guard.Against.NullOrEmpty(createdBy);
  }
}
