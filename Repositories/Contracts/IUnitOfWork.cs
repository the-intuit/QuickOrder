namespace Menu.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    } 
}
