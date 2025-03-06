using Ardalis.GuardClauses;

namespace eCiliation.SharedKernel;

public static class DeactivationExtensions
{
  public static bool Deactivation(this IGuardClause guardClause,
    bool isCurrentlyActive,
    bool setToInactive)
  {   
    if (isCurrentlyActive == false)
      throw new ArgumentException("Already inactive.");

    if (setToInactive == true)
      throw new ArgumentException("No action taken.");

    return false;
  }
}
