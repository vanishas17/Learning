using ExpenseApproval.API.Entities;
using ExpenseApproval.API.Models;

namespace ExpenseApproval.API.Contracts
{
    public interface IUserBudgetService
    {
        double GetAvailableBudgetForUser(UserBudget userbudget);
        int SetBudgetForUser(UserBudget userBudget);
    }
}
