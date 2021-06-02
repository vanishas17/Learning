using ExpenseApproval.Common.Utils;
using ExpenseApproval.DataAccess.DbContexts;
using ExpenseApproval.DataAccess.Entities;
using ExpenseApproval.DataAccess.Repository;
using ExpenseApproval.Service.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.Service.Expense
{
    public class UserExpenseService : IUserExpenseService
    {
        private readonly ILoggerService _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserExpenseService(IRepositoryWrapper repositoryWrapper, ILoggerService logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }

        public bool AddExpense(UserExpense expense)
        {
            
            expense.Status = ExpenseStatus.Submitted.ToString();

            try
            {
                _repositoryWrapper.Expense.Add(expense);
                _repositoryWrapper.Save();

                return true;
            }
            catch(Exception ex)
            {
                Task.Run(() => _logger.Log(LogType.Error, "AddExpense", "", "", ex, "Add Expense failed"));
            }

            return false;

        }

        public IEnumerable<UserExpense> GetAllExpenses()
        {
            try
            {
                return _repositoryWrapper.Expense.GetAll();
            }
            catch(Exception ex)
            {
                Task.Run(() => _logger.Log(LogType.Error, "GetAllExpenses", "", "", ex, "GetAllExpenses failed"));
            }

            return null;
        }

        public IEnumerable<UserExpense> GetAllExpensesByUserId(Guid id)
        {
            try
            {
                var userExpenses = _repositoryWrapper.Expense.GetByCondition(s => s.UserID == id);
                return userExpenses;
            }
            catch (Exception ex)
            {
                Task.Run(() => _logger.Log(LogType.Error, "GetAllExpensesByUserId", "", "", ex, "GetAllExpensesByUserId failed"));
            }
            return null;
        }

        public bool UpdateExpense(UserExpense expense)
        {
            try
            {
                UserExpense userExpense = _repositoryWrapper.Expense.GetByCondition(c => c.ExpenseID == expense.ExpenseID).FirstOrDefault();
                if(userExpense != null)
                {
                    _repositoryWrapper.Expense.Update(userExpense);
                    _repositoryWrapper.Save();
                }

                return true;
            }
            catch(Exception ex)
            {
                Task.Run(() => _logger.Log(LogType.Error, "UpdateExpense", "", "", ex, "UpdateExpense failed"));
            }
            return false;
        }

        
    }
}
