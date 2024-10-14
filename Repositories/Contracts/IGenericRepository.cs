namespace Menu.Repositories.Contracts
{
    public interface IGenericRepository<TEntity>
    {
        TEntity FindById(object id);
        void DeleteById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
