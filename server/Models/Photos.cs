using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Models;

public class Photos {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Photo { get; set; } = null!;
}