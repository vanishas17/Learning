using ExpenseApproval.API.Contracts;
using ExpenseApproval.API.DbContexts;
using ExpenseApproval.API.Entities;
using System;
using System.Linq;

namespace ExpenseApproval.API.Services
{
    public class UserBudgetService : IUserBudgetService
    {
        private readonly ExpenseDataContext _context;

        public UserBudgetService(ExpenseDataContext context)
        {
            _context = context;
        }
        public double GetAvailableBudgetForUser(Guid userId, int budgetYear)
        {

           double amount = Convert.ToDouble(_context.UserBudget.Where(s => s.UserID == userId && s.BudgetYear == budgetYear).Select(s=>s.Amount));

            return amount;
            
        }

        public int SetBudgetForUser(UserBudget userBudget)
        {
            try
            {
                _context.Update(userBudget);
                var count = _context.SaveChanges();

                return count;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
