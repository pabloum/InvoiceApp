namespace InvoiceApp.Persistence;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    Task Insert(T entity);
    Task Delete(int id);
}
