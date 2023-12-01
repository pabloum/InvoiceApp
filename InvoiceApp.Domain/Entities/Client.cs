namespace InvoiceApp.Domain;

public class Client
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public IEnumerable<Invoice> Invoices { get; set; } = new List<Invoice>();
}
