using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoObjects.Converters;

namespace MongoObjects;

public class BsonDocument
{
    [BsonId]
    // [BsonRepresentation(BsonType.ObjectId)]
    [JsonConverter(typeof(ObjectIdConverter))]
    public Guid  Id { get; set; }
}