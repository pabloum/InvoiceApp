using InvoiceApp.Domain;
using Microsoft.Data.SqlClient;

namespace InvoiceApp.Persistence;

public class ProductRepository : BaseRepository<Product>, IProductRepository 
{
    public ProductRepository(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }
}
