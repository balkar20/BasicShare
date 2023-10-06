namespace Core.Base.EventSourcing;

public record struct EventDescriptor(Guid Id, Event EventData, int Version);