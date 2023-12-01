using InvoiceApp.Domain;

namespace InvoiceApp.Persistence;

public class OrderRepository : BaseRepository<Order>, IOrderRepository 
{
    public OrderRepository(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}