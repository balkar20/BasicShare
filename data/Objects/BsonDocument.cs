using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Data.Base.Objects.Converters;

namespace Data.Base.Objects;

public class BsonDocument
{
    [BsonId]
    // [BsonRepresentation(BsonType.ObjectId)]
    [JsonConverter(typeof(ObjectIdConverter))]
    public Guid  Id { get; set; }
}