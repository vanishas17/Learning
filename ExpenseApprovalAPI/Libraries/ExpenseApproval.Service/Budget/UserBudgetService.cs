using ExpenseApproval.DataAccess;
using ExpenseApproval.DataAccess.DbContexts;
using ExpenseApproval.DataAccess.Entities;
using ExpenseApproval.DataAccess.Repository;
using ExpenseApproval.Service.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.Service.Budget
{
    public class UserBudgetService : IUserBudgetService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILoggerService _logger;


        public UserBudgetService(IRepositoryWrapper repositoryWrapper, ILoggerService logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }
        public double GetAvailableBudgetForUser(Guid userId, int budgetYear)
        {

            double amount = 0.0;
            try
            {
                amount = Convert.ToDouble(_repositoryWrapper.Budget.GetByCondition(s => s.UserID == userId && s.BudgetYear == budgetYear).Select(s => s.Amount));
            }
            catch (Exception ex)
            {
                Task.Run(() => _logger.Log(LogType.Error, "GetAvailableBudgetForUser", "", "", ex, "GetAvailableBudgetForUser failed"));
            }
            return amount;

        }

        public bool SetBudgetForUser(UserBudget userBudget)
        {
            try
            {
                _repositoryWrapper.Budget.Update(userBudget);
                _repositoryWrapper.Save();

                return true;
            }
            catch (Exception ex)
            {
                Task.Run(() => _logger.Log(LogType.Error, "SetBudgetForUser", "", "", ex, "SetBudgetForUser failed"));
            }
            return false;
        }
    }
}
