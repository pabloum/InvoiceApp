namespace InvoiceApp.Persistence;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    int Insert(T entity);
    int Delete(int id);
}
