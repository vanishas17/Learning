using ExpenseApproval.DataAccess.DbContexts;
using ExpenseApproval.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseApproval.DataAccess.Repository.EntityRepository
{
    public class BudgetRepository : RepositoryBase<UserBudget>, IBudgetRepository
    {
        public BudgetRepository(ExpenseDataContext context) : base(context)
        {
        }
    }
}
