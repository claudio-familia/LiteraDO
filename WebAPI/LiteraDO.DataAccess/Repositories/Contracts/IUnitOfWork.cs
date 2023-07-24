using Microsoft.EntityFrameworkCore.Storage;

namespace LiteraDO.DataAccess.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IDbContextTransaction CreateTransaction();
        int SaveChanges();
    }
}
