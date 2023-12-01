namespace InvoiceApp.Domain;

public class Invoice
{
    public int Id { get; set; }
    public decimal? SubTotal { get; set; }
    public decimal? Tax { get; set; }
    public decimal? Total { get; set; }
    public int ClientId { get; set; }
    public Client? Client { get; set; }
    public IEnumerable<Order>? Orders { get; set; }
}
