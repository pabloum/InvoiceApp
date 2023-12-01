using InvoiceApp.Domain;
using Microsoft.Data.SqlClient;

namespace InvoiceApp.Persistence;

public class OrderRepository : BaseRepository<Order>, IOrderRepository 
{
    public OrderRepository(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }
}