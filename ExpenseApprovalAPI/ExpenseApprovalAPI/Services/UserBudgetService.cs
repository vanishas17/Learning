using ExpenseApproval.API.Contracts;
using ExpenseApproval.API.DbContexts;
using ExpenseApproval.API.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Services
{
    public class UserBudgetService : IUserBudgetService
    {
        private readonly ExpenseDataContext _context;
        private readonly ILoggerService _logger;


        public UserBudgetService(ExpenseDataContext context, ILoggerService logger)
        {
            _context = context;
            _logger = logger;
        }
        public double GetAvailableBudgetForUser(Guid userId, int budgetYear)
        {

            double amount = 0.0;
            try
            {
                amount = Convert.ToDouble(_context.UserBudget.Where(s => s.UserID == userId && s.BudgetYear == budgetYear).Select(s => s.Amount));
            }
            catch (Exception ex)
            {
                Task.Run(() => _logger.Log(LogType.Error, "GetAvailableBudgetForUser", "", "", ex, "GetAvailableBudgetForUser failed"));
            }
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
            catch (Exception ex)
            {
                Task.Run(() => _logger.Log(LogType.Error, "SetBudgetForUser", "", "", ex, "SetBudgetForUser failed"));
            }
            return 0;
        }
    }
}
