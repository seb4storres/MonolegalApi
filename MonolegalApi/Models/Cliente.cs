using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MonolegalApi.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("CodigoFactura")]
        public string CodigoFactura { get; set; } = null!;

        [BsonElement("Ciudad")]
        public string Ciudad { get; set; } = null!;

        [BsonElement("TotalFactura")]
        public int TotalFactura { get; set; } 

        [BsonElement("Subtotal")]
        public int Subtotal { get; set; } 

        [BsonElement("Iva")]
        public int Iva { get; set; } 

        public string Estado { get; set; } = null!;

        public bool Pagada { get; set; } = false;


    }
}
