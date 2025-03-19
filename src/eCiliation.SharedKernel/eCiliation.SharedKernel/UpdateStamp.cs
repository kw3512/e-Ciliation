using Ardalis.GuardClauses;

namespace eCiliation.SharedKernel;
public class UpdateStamp
{
  // ComplexProperty Note: (3/19/2025)
  // The individual props (updatedOn & UpdateBy) are nullable b/c
  // complex properties as optional is not supported in EF Core 8 or 9.
  public DateTime? UpdatedOn { get; private set; } 
  public string? UpdatedBy { get; private set; } = string.Empty;

  public UpdateStamp(string updatedBy) : this()
  {
    if (updatedBy is not null)
    {
      UpdatedBy = Guard.Against.NullOrEmpty(updatedBy);
      UpdatedOn = DateTime.Now;
    }
  }
  public UpdateStamp()
  {
  }
}
