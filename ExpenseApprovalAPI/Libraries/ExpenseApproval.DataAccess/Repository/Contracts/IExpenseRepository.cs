using ExpenseApproval.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseApproval.DataAccess.Repository
{
    public interface IExpenseRepository : IRepositoryBase<UserExpense>
    {
    }
}
