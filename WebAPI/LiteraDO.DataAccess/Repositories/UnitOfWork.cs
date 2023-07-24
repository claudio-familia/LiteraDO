using Microsoft.EntityFrameworkCore.Storage;
using System;
using LiteraDO.DataAccess.Repositories.Contracts;

namespace LiteraDO.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LiteraDODBContext _DataContext;

        public UnitOfWork(LiteraDODBContext dataContext)
        {
            _DataContext = dataContext;
        }

        public IDbContextTransaction CreateTransaction()
        {
            return this._DataContext.Database.BeginTransaction();
        }

        public int SaveChanges()
        {
            return _DataContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_DataContext != null)
            {
                _DataContext.Dispose();
            }
        }
    }
}
