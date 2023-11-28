namespace Core.Base.EventSourcing;

public record  EventDescriptor(Guid Id, Event EventData, int Version);