using ExpenseApproval.API.Entities;
using ExpenseApproval.API.Models;
using System;

namespace ExpenseApproval.API.Contracts
{
    public interface IUserBudgetService
    {
        double GetAvailableBudgetForUser(Guid userId, int budgetYear);
        int SetBudgetForUser(UserBudget userBudget);
    }
}
