using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace InvoiceApp.Persistence;

public class BaseRepository<T> : IRepository<T>
{
    private readonly SqlConnection _connection;
    private SqlTransaction _transaction;
    
    public BaseRepository(UnitOfWork unitOfWork)
    {
        _connection = unitOfWork.Connection;
        _transaction = unitOfWork.Transaction;
    }

    public IEnumerable<T> GetAll()
    {
        var sql = $"SELECT * FROM {GetTableName()}";     
        return _connection.Query<T>(sql); 
    }
    
    public T? GetById(int id)
    {
        var sql = $"SELECT * FROM {GetTableName()} WHERE Id = @Id";                 
        return _connection.QueryFirstOrDefault<T>(sql, new { Id = id}); 
    }

    public int Insert(T entity)
    {
        return _connection.Execute($"INSERT INTO {GetTableName()} VALUES (@Property1, @Property2, ...)", entity);
    }

    public int Delete(int id)
    {
        return _connection.Execute($"DELETE FROM {GetTableName()} WHERE Id = @Id", new { Id = id });
    }

    private string GetTableName()
    {
        return typeof(T).Name + "s";
    }
}
