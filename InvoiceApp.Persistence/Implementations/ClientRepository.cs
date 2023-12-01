using InvoiceApp.Domain;

namespace InvoiceApp.Persistence;

public class ClientRepository : BaseRepository<Product>, IClientRepository 
{
    public ClientRepository(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
