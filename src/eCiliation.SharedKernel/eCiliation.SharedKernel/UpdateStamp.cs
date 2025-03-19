using Ardalis.GuardClauses;

namespace eCiliation.SharedKernel;
public class UpdateStamp
{
  public DateTime? UpdatedOn { get; private set; }
  public string? UpdatedBy { get; private set; }

  public UpdateStamp(string? updatedBy)
  {
    if (updatedBy is not null)
    {
      UpdatedBy = Guard.Against.NullOrEmpty(updatedBy);
      UpdatedOn = DateTime.Now;
    }
  }
}
