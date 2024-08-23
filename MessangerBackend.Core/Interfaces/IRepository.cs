using System.Linq.Expressions;

namespace MessangerBackend.Core.Interfaces;

public interface IRepository
{
    Task<T> Add<T>(T entity) where T : class;
    Task<T> Update<T>(T entity) where T : class;
    Task<T> Delete<T>(int id) where T : class;

    Task<T> GetById<T>(int id) where T : class;
    IQueryable<T> GetAll<T>() where T : class;
    Task<IEnumerable<T>> GetQuery<T>(Expression<Func<T, bool>> func) where T : class;
}