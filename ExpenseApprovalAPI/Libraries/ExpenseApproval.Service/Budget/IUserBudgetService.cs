using ExpenseApproval.DataAccess.Entities;
using System;

namespace ExpenseApproval.Service.Budget
{
    public interface IUserBudgetService
    {
        double GetAvailableBudgetForUser(Guid userId, int budgetYear);
        bool SetBudgetForUser(UserBudget userBudget);
    }
}
