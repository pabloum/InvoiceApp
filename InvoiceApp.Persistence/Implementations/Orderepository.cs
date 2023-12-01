using InvoiceApp.Domain;

namespace InvoiceApp.Persistence;

public class Orderepository : BaseRepository<Product>, IOrderRepository 
{
    public Orderepository(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}