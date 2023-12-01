using InvoiceApp.Domain;

namespace InvoiceApp.Persistence;

public class ClientRepository : BaseRepository<Client>, IClientRepository 
{
    public ClientRepository(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
