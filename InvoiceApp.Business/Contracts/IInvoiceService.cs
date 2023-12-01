using InvoiceApp.Domain;

namespace InvoiceApp.Business;

public interface IInvoiceService
{
    Invoice CreateInvoice(Invoice invoice);
}
