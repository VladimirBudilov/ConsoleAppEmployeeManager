using Application.Base;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace Infrastructure.EventStore;

public class JsonEventStore : IEventStore
{
    private readonly string _filePath;
    private Dictionary<int, List<Event>> _eventStore = new Dictionary<int, List<Event>>();

    public JsonEventStore(string filePath)
    {
        _filePath = filePath;
        LoadEventsFromFile();
    }

    public async Task SaveEventsAsync(int aggregateId, IEnumerable<Event> events, int expectedVersion)
    {
        if (!_eventStore.TryGetValue(aggregateId, out var eventList))
        {
            eventList = new List<Event>();
            _eventStore[aggregateId] = eventList;
        }

        if (eventList.Count != expectedVersion)
            throw new InvalidOperationException("Concurrency conflict");

        eventList.AddRange(events);
        await SaveEventsToFile();
    }

    public async Task<List<Event>> GetEventsAsync(int aggregateId)
    {
        if (_eventStore.TryGetValue(aggregateId, out var eventList))
        {
            return eventList;
        }

        return new List<Event>();
    }

    private void LoadEventsFromFile()
    {
        if (File.Exists(_filePath))
        {
            var jsonData = File.ReadAllText(_filePath);
            var storedEvents = JsonConvert.DeserializeObject<Dictionary<int, List<Event>>>(jsonData);
            if (storedEvents != null)
            {
                _eventStore = storedEvents;
            }
        }
    }

    private async Task SaveEventsToFile()
    {
        var jsonData = JsonConvert.SerializeObject(_eventStore, (Newtonsoft.Json.Formatting)Formatting.Indented);
        await File.WriteAllTextAsync(_filePath, jsonData);
    }
}
