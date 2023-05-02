using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.Interfaces.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace ExpenseManagement.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly Contexts.ExpenseManagementContext Context;
        
        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(Contexts.ExpenseManagementContext context)
        {
            Context = context;
        }

        public IBaseRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type))
                return (IBaseRepository<T>)_repositories[type];

            var repositoryType = typeof(BaseRepository<>);

            var repositoryInstance =
                Activator.CreateInstance(repositoryType
                    .MakeGenericType(typeof(T)), Context);

            _repositories.Add(type, repositoryInstance);

            return (IBaseRepository<T>)_repositories[type];
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    Context.Dispose();
            _disposed = true;
        }
    }
}
