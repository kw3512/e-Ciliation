using Ardalis.GuardClauses;

namespace eCiliation.SharedKernel;
public class UpdateStamp
{
  public DateTime UpdatedOn { get; private set; }
  public string UpdatedBy { get; private set; }

  public UpdateStamp(string updatedBy)
  {
    UpdatedBy = Guard.Against.NullOrEmpty(updatedBy);
  }

  public void SetUpdatedOn()
  {
    UpdatedOn = DateTime.Now;
  }
}
