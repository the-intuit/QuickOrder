using Menu.Data;
using Menu.Repositories.EF.Contracts;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Text;

namespace Menu.Repositories.EF.Services
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        private bool _disposed;
        private readonly DataBaseMenuOrderContext _context;

        public IEfGenericRepository<EmployeeData> EmployeeRepository { get; private set; }
        public EfUnitOfWork(DataBaseMenuOrderContext context, IEfGenericRepository<EmployeeData> employeeRepository)
        {
            _context = context;
            EmployeeRepository = employeeRepository;
        }


        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var error in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("Entity of type '{0}' in state '{1}' has the following validation errors:", error.Entry.Entity.GetType().Name, error.Entry.State);
                    foreach (var ve in error.ValidationErrors)
                    {
                        sb.AppendLine();
                        sb.AppendFormat("- Property: '{0}', Error: '{1}'", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var sb = new StringBuilder();
                foreach (var entry in ex.Entries)
                {
                    sb.AppendFormat("Update of entry of type '{0}' in state '{1}' failed with concurrency error. ", entry.Entity.GetType().Name, entry.State);
                    sb.AppendLine("Original Values: - ");

                    foreach (var origPropName in entry.OriginalValues.PropertyNames)
                    {
                        var value = entry.OriginalValues[origPropName];
                        sb.AppendFormat("Property: {0}, Value: {1} ", origPropName, value);
                    }

                    sb.AppendLine("Current Values: - ");
                    foreach (var currentPropName in entry.CurrentValues.PropertyNames)
                    {
                        var value = entry.OriginalValues[currentPropName];
                        sb.AppendFormat("Property: {0}, Value: {1} ", currentPropName, value);
                    }
                }
                throw;
            }
        }

        public void Rollback()
        {
            Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
