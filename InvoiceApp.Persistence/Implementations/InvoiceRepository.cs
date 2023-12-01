using InvoiceApp.Domain;
using Microsoft.Data.SqlClient;

namespace InvoiceApp.Persistence;

public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository 
{
    public InvoiceRepository(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }
}
