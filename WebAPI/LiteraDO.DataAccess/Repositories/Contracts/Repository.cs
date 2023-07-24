using LiteraDO.Common.Models;

namespace LiteraDO.DataAccess.Repositories.Contracts
{
    public class Repository<TEntity> : RepositoryBase<TEntity, LiteraDODBContext> where TEntity : class, IAuditableEntity, new()
    {
        public Repository(LiteraDODBContext context) : base(context) { }
    }
}
