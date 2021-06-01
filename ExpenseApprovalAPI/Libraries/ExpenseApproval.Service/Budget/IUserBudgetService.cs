using ExpenseApproval.DataAccess.Entities;
using System;

namespace ExpenseApproval.Service.Budget
{
    public interface IUserBudgetService
    {
        double GetAvailableBudgetForUser(Guid userId, int budgetYear);
        int SetBudgetForUser(UserBudget userBudget);
    }
}
