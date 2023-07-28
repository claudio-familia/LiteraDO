using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LiteraDO.Common.Models;

namespace LiteraDO.BusinessLogic.Services.Contracts
{
    public interface IBaseService<T>
    {
        T Add(T entity);
        T Update(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null);
        T Get(int id);
        T GetEntity(int id);
        T Get(Guid id);
        TResult Get<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null);
        bool Exists(int id);
        bool Exists(Expression<Func<T, bool>> filter = null);
        T Delete(T entity);
    }
}
