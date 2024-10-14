using Menu.Repositories.Contracts;
using System.Linq.Expressions;

namespace Menu.Repositories.EF.Contracts
{
    public interface IEfGenericRepository<TEntity> : IGenericRepository<TEntity>
    {
        IQueryable<TEntity> AsQueryable(params Expression<Func<TEntity, object>>[] includes);

        void Delete(TEntity entity);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression);
    }
}
