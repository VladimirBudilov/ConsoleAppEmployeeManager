namespace Application.Base;

public abstract class Event
{
    public int Version { get; set; }
    public DateTimeOffset Timestamp { get; private set; }

    protected Event()
    {
        Timestamp = DateTimeOffset.UtcNow;
    }
}