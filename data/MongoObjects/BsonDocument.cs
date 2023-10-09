using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoObjects;

public class BsonDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}