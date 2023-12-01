using InvoiceApp.Domain;

namespace InvoiceApp.Persistence;

public class InvoiceRepository : BaseRepository<Product>, IInvoiceRepository 
{
    public InvoiceRepository(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
