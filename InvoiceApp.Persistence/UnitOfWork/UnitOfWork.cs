using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace InvoiceApp.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly SqlConnection _connection;
    private readonly SqlTransaction _transaction;
    private IProductRepository _productRepository;
    private IOrderRepository _orderRepository;
    private IInvoiceRepository _invoiceRepository;
    private IClientRepository _clientRepository;

    public UnitOfWork(SqlConnection sqlConnection
                    , IProductRepository productRepository
                    , IOrderRepository orderRepository
                    , IInvoiceRepository invoiceRepository
                    , IClientRepository clientRepository)
    {
        _connection = sqlConnection;
        _connection.Open();
        _transaction = _connection.BeginTransaction();
        _productRepository = productRepository;
        _orderRepository = orderRepository;
        _invoiceRepository = invoiceRepository;
        _clientRepository = clientRepository;
    }

    public SqlConnection Connection => _connection;

    public SqlTransaction Transaction => _transaction;

    public IProductRepository ProductRepository => _productRepository;

    public IOrderRepository OrderRepository => _orderRepository;

    public IInvoiceRepository InvoiceRepository => _invoiceRepository;

    public IClientRepository ClientRepository => _clientRepository;

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
