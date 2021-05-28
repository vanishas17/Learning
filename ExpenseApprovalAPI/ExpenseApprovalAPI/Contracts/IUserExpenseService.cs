using ExpenseApproval.API.Entities;
using System;
using System.Collections.Generic;

namespace ExpenseApproval.API.Contracts
{
    public interface IUserExpenseService
    {
        IEnumerable<UserExpense> GetAllExpenses();
        IEnumerable<UserExpense> GetAllExpensesByUserId(Guid id);
        bool AddExpense(UserExpense expense);
        bool UpdateExpense(UserExpense expense);


    }
}
