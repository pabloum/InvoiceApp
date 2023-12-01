using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace InvoiceApp.Persistence;

public class BaseRepository<T> : IRepository<T>
{
    public readonly string _connectionString;
    
    public BaseRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DataBase") ?? String.Empty;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        using (var connection = new SqlConnection(_connectionString)) 
        {
            await connection.OpenAsync();
            var sql = $"SELECT * FROM {GetTableName()}";     
            return connection.Query<T>(sql); 
        }
    }
    
    public async Task<T?> GetById(int id)
    {
        using (var connection = new SqlConnection(_connectionString)) 
        {
            await connection.OpenAsync();
            var sql = $"SELECT * FROM {GetTableName()} WHERE Id = @Id";                 
            return connection.QueryFirstOrDefault<T>(sql, new { Id = id}); 
        }
    }

    public async Task Insert(T entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            connection.Execute($"INSERT INTO {GetTableName()} VALUES (@Property1, @Property2, ...)", entity);
        }
    }

    public async Task Delete(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            connection.Execute($"DELETE FROM {GetTableName()} WHERE Id = @Id", new { Id = id });
        }
    }

    private string GetTableName()
    {
        return typeof(T).Name + "s";
    }
}
