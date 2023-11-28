
using MongoDB.Bson;
using Newtonsoft.Json;
using JsonReader = MongoDB.Bson.IO.JsonReader;

namespace MongoObjects.Converters;

public class ObjectIdConverter: JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    { 
        serializer.Serialize(writer, value.ToString());
       
    }

    public override object? ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override bool CanConvert(Type objectType)
    {
        return typeof(ObjectId).IsAssignableFrom(objectType);
        //return true;
    }
}