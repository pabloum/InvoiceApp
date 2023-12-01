using InvoiceApp.Domain;
using Microsoft.Data.SqlClient;

namespace InvoiceApp.Persistence;

public class ClientRepository : BaseRepository<Client>, IClientRepository 
{
    public ClientRepository(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }
}
