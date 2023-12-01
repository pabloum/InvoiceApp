using InvoiceApp.Domain;

namespace InvoiceApp.Persistence;

public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository 
{
    public InvoiceRepository(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
