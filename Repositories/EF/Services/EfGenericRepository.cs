using Menu.Data;
using Menu.Repositories.EF.Contracts;
using Menu.Repositories.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Menu.Repositories.EF.Services
{
    public class EfGenericRepository<TEntity> : IEfGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly DbSet<TEntity> _dbSet;
        protected readonly DataBaseMenuOrderContext Context;
        public EfGenericRepository(DataBaseMenuOrderContext context)
        {
            Context = context;
            _dbSet = Context.Set<TEntity>();
        }
        public TEntity FindById(object id)
        {
            return _dbSet.Find(id);
        }

        public void DeleteById(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> AsQueryable(params Expression<Func<TEntity, object>>[] includes)
        {
            return includes == null
                ? Context.Set<TEntity>()
                : Context.Set<TEntity>().IncludeMultiple(includes);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return AsQueryable().Where(expression).FirstOrDefault();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return AsQueryable().Where(expression).SingleOrDefault();
        }
    }
}
