using ExpenseApproval.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Handlers
{
    public interface IExpenseHandler
    {
        public bool UpdateExpense(UserExpense expense);
    }
}
