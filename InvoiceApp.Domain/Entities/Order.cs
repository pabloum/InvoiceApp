namespace InvoiceApp.Domain;

public class Order 
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int InvoiceId { get; set; }
    public Invoice? Invoice { get; set; }
}
