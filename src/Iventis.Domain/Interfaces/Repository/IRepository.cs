using Iventis.Domain.Entities;
using System.Linq.Expressions;

namespace Iventis.Domain.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        Task Add(T entity);
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Task Update(T entity);
        Task Delete(Guid id);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();
    }
}
