using MongoDB.Bson.Serialization.Attributes;

namespace CQRSBook.Domain.Entities;

public class Book
{
    [BsonId]
    [BsonElement("_id")]
    public long BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    public int Pages { get; set; }
    public string Genre { get; set; }
    public string Language { get; set; }
    public decimal Price { get; set; }
}
