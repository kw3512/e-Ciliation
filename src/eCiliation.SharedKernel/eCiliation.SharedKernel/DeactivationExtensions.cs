using Ardalis.GuardClauses;

namespace eCiliation.SharedKernel;

public static class DeactivationExtensions
{
  public static bool Deactivation(this IGuardClause guardClause,
    bool isCurrentlyActive)
  {   
    if (isCurrentlyActive is false)
      throw new ArgumentException("Already inactive.");

    return false;
  }
}
