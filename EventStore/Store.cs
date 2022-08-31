using System.Text.Json.Serialization;
using EventStore.Events;
using Newtonsoft.Json;

namespace EventStore;

public class Store
{
    private long SeqNr { get; set; }
    
    //This is a table of database
    private List<StoredEvent> Events { get; set; } = new();
    private Dictionary<Guid, int> Versions { get; set; } = new();

    private JsonSerializerSettings Settings { get; } = new ()
    {
        TypeNameHandling = TypeNameHandling.All
    };
    public void AddEvents(List<Event> evts, Guid aggregateId)
    {
        int version = -1;
        Versions.TryGetValue(aggregateId, out version);
        foreach (var evt in evts)
        {
            var se = new StoredEvent()
            {
                SeqNumber = SeqNr++,
                Version = version ++,//Version - if you need concurrency issues handling
                AggregateId = aggregateId,
                EventData = JsonConvert.SerializeObject(evt, Settings)
            };
            Events.Add(se);
        }

        // if (Versions.ContainsKey(aggregateId))
        // {
        //     Versions[aggregateId] 
        // }
        // {
        //     
        // }
    }

    public ICollection<Event> LoadEvents(Guid id)
    {
        return Events
            .Where(evt => evt.AggregateId == id)
            .Select(evt => JsonConvert.DeserializeObject<Event>(evt.EventData, Settings))
            .ToList();
    }
}

public class StoredEvent
{
    public long SeqNumber { get; set; }
    public Guid AggregateId { get; set; }
    public string? EventData { get; set; }
    public int Version { get; set; }
}