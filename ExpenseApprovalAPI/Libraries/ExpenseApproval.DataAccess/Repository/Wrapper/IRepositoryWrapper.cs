using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseApproval.DataAccess.Repository
{
    public interface IRepositoryWrapper 
    {
        IUserRepository User { get; }
        IBudgetRepository Budget { get; }
        IExpenseRepository Expense { get; }
        void Save();

    }
}
