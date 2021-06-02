using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExpenseApproval.DataAccess.Repository
{
    public interface IRepositoryBase<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);

    }
}
