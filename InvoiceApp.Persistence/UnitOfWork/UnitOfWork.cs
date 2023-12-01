using Microsoft.Data.SqlClient;

namespace InvoiceApp.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly SqlConnection _connection;
    private readonly SqlTransaction _transaction;
    private IProductRepository _productRepository;
    private IOrderRepository _orderRepository;
    private IInvoiceRepository _invoiceRepository;
    private IClientRepository _clientRepository;

    public UnitOfWork(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
        _connection.Open();
        _transaction = _connection.BeginTransaction();
    }

    public SqlConnection Connection => _connection;
    public SqlTransaction Transaction => _transaction;

    public IProductRepository ProductRepository 
    {
        get
        {
            return _productRepository ??= new ProductRepository(this);
        }
    }
    public IOrderRepository OrderRepository 
    {
        get
        {
            return _orderRepository ??= new OrderRepository(this);
        }
    }
    public IInvoiceRepository InvoiceRepository 
    {
        get
        {
            return _invoiceRepository ??= new InvoiceRepository(this);
        }
    }
    public IClientRepository ClientRepository 
    {
        get
        {
            return _clientRepository ??= new ClientRepository(this);
        }
    }
    public void Commit()
    {
        _transaction?.Commit();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _connection?.Dispose();
    }
}
