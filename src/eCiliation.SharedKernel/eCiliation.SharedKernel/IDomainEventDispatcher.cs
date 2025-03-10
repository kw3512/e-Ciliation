namespace eCiliation.SharedKernel;

public interface IDomainEventDispatcher
{
  Task DispatchAndClearEvents(IEnumerable<IHaveDomainEvents> entitiesWithEvents);
}
