using Iventis.Domain.Entities;
using Iventis.Domain.Interfaces;
using Iventis.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Iventis.Infrastructure.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity, new() // pode dar um new nessa entity
    {
        protected readonly IventisContext _context;
        protected readonly DbSet<T> DbSet;

        public Repository(IventisContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }
        public virtual async Task Add(T entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
