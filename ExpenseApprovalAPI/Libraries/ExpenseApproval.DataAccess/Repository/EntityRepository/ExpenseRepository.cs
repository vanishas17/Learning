using ExpenseApproval.DataAccess.DbContexts;
using ExpenseApproval.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseApproval.DataAccess.Repository.EntityRepository
{
    public class ExpenseRepository : RepositoryBase<UserExpense>, IExpenseRepository
    {
        public ExpenseRepository(ExpenseDataContext context) : base(context)
        {
        }
    }
}
