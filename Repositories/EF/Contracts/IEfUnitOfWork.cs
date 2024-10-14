using Menu.Data;
using Menu.Repositories.Contracts;

namespace Menu.Repositories.EF.Contracts
{
    public interface IEfUnitOfWork : IUnitOfWork
    {
        IEfGenericRepository<EmployeeData> EmployeeRepository { get; }
    }
}
