using System.Linq.Expressions;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> Query();

    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);
    Task<T> Update(T entity);
    Task DeleteAsync(Guid id);

    Task SaveAsync();

}