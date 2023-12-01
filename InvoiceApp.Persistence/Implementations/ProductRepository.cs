using InvoiceApp.Domain;

namespace InvoiceApp.Persistence;

public class ProductRepository : BaseRepository<Product>, IProductRepository 
{
    public ProductRepository(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
