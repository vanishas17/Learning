using ExpenseApproval.API.Contracts;
using ExpenseApproval.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Handlers
{
    public class ExpenseHandler :IExpenseHandler
    {
        private readonly IUserExpenseService _userExpenseService;
        private readonly IUserBudgetService _userBudgetService;
        public ExpenseHandler(IUserBudgetService userBudgetService, IUserExpenseService userExpenseService)
        {
            _userBudgetService = userBudgetService;
            _userExpenseService = userExpenseService;
        }

        public bool UpdateExpense(UserExpense expense)
        {
            try
            {
                var availableAmount = _userBudgetService.GetAvailableBudgetForUser(expense.UserID, expense.ExpenseDate.Year);
                if(availableAmount > expense.Amount)
                {
                    return _userExpenseService.UpdateExpense(expense);
                } else
                {
                    //No sufficient amount for the given year
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
