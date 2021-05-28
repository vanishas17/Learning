using ExpenseApproval.API.Contracts;
using ExpenseApproval.API.DbContexts;
using ExpenseApproval.API.Entities;
using ExpenseApproval.API.Helper;
using ExpenseApproval.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Services
{
    public class UserExpenseService : IUserExpenseService
    {
        private readonly ExpenseDataContext _context;
        private readonly ILoggerService _logger;

        public UserExpenseService(ExpenseDataContext context, ILoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool AddExpense(UserExpense expense)
        {
            
            expense.Status = ExpenseStatus.Submitted.ToString();

            try
            {
                _context.UserExpenses.Add(expense);
                _context.SaveChanges();

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
                return _context.UserExpenses;
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
                var userExpenses = _context.UserExpenses.Where(s => s.UserID == id);
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
                UserExpense userExpense = _context.UserExpenses.Find(expense.ExpenseID);
                if(userExpense != null)
                {   
                    _context.UserExpenses.Update(userExpense);
                    _context.SaveChanges();
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
