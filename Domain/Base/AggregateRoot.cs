namespace Application.Base;

public abstract class AggregateRoot
{
    private readonly List<Event> _changes = new List<Event>();
    public Guid Id { get; protected set; }
    public int Version { get; private set; } = -1;
    public IEnumerable<Event> GetUncommittedChanges() => _changes.AsEnumerable();
    public void MarkChangesAsCommitted() => _changes.Clear();

    protected void ApplyChange(Event @event, bool isNew = true)
    {
        ((dynamic)this).Apply((dynamic)@event);
        if (isNew) _changes.Add(@event);
    }
}
