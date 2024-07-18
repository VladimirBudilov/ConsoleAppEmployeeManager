
using Application.Base;

namespace Infrastructure.EventStore;

public interface IEventStore
{
    Task SaveEventsAsync(int aggregateId, IEnumerable<Event> events, int expectedVersion);
    Task<List<Event>> GetEventsAsync(int aggregateId);
}