using ExpenseApproval.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExpenseApproval.DataAccess.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        private readonly ExpenseDataContext _context;

        public RepositoryBase(ExpenseDataContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
