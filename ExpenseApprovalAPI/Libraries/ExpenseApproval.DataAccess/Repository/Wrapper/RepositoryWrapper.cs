using ExpenseApproval.DataAccess.DbContexts;
using ExpenseApproval.DataAccess.Repository.EntityRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseApproval.DataAccess.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper, IDisposable
    {
        private ExpenseDataContext _context;

        private IUserRepository _user;
        private IBudgetRepository _budget;
        private IExpenseRepository _expense;

        public RepositoryWrapper(ExpenseDataContext context)
        {
            _context = context;
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }

                return _user;
            }
        }
        public IBudgetRepository Budget
        {
            get
            {
                if (_budget == null)
                {
                    _budget = new BudgetRepository(_context);
                }

                return _budget;
            }
        }

        public IExpenseRepository Expense
        {
            get
            {
                if (_expense == null)
                {
                    _expense = new ExpenseRepository(_context);
                }

                return _expense;
            }
        }
        
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
