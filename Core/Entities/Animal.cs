using Core.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Animal
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("breed")]
        public string Breed { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [BsonElement("status")]
        public Status Status { get; set; }

        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
    }
}
