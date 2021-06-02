using ExpenseApproval.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Handlers
{
    public interface IExpenseHandler
    {
        public void UpdateExpense(UserExpense expense);
    }
}
