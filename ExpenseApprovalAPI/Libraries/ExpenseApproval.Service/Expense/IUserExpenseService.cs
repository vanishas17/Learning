using ExpenseApproval.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace ExpenseApproval.Service.Expense
{
    public interface IUserExpenseService
    {
        IEnumerable<UserExpense> GetAllExpenses();
        IEnumerable<UserExpense> GetAllExpensesByUserId(Guid id);
        void AddExpense(UserExpense expense);
        void UpdateExpense(UserExpense expense);


    }
}
