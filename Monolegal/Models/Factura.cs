using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Monolegal.Models
{
    public class Factura
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("codigoFactura")]
        public string CodigoFactura { get; set; } = null!;

        [BsonElement("ciudad")]
        public string Ciudad { get; set; } = null!;

        [BsonElement("totalFactura")]
        public int TotalFactura { get; set; }

        [BsonElement("subtotal")]
        public int Subtotal { get; set; }

        [BsonElement("iva")]
        public int Iva { get; set; }

        [BsonElement("estado")]
        public string Estado { get; set; } = null!;

        [BsonElement("pagada")]
        public bool Pagada { get; set; } = false;


    }
}
