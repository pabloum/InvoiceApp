using System.Reflection.Metadata;

namespace InvoiceApp.Domain;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal? UnitPrice { get; set; }
    public Blob Image { get; set; }
}
