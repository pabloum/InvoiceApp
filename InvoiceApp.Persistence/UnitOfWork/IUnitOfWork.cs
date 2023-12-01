using Microsoft.Data.SqlClient;

namespace InvoiceApp.Persistence;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    void Rollback();
    SqlConnection Connection { get; }
    SqlTransaction Transaction { get; }
}