using ExpenseApproval.API.Contracts;
using ExpenseApproval.API.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExpenseApproval.Tests.MockServices
{
    class UserExpenseServiceMock : IUserExpenseService
    {
        private readonly IEnumerable<UserExpense> _userExpenses;
        public UserExpenseServiceMock()
        {
            _userExpenses = new List<UserExpense>()
            {
                new UserExpense()
                {
                    UserID= new Guid("85CF0D9D-EB2A-4913-AEA6-E8A661150BC9"),
                    ExpenseType="travel",
                    Amount=1000,
                    ExpenseDate = new DateTime(2020,07,1),
                    Status="Submitted",
                    ExpenseID= new Guid("404DACDD-EECE-4934-A91A-20825D6BAAA0")
                },
                new UserExpense()
                {
                    UserID= new Guid("85CF0D9D-EB2A-4913-AEA6-E8A661150BC9"),
                    ExpenseType="food",
                    Amount=800,
                    ExpenseDate = new DateTime(2020,04,14),
                    Status="Submitted",
                    ExpenseID= new Guid("17F9B299-F045-4862-98F0-4F4FCD276671")
                },
                new UserExpense()
                {
                    UserID= new Guid("E741539C-7606-4C7C-BD85-D273C7D385BB"),
                    ExpenseType="medical",
                    Amount=1500,
                    ExpenseDate = new DateTime(2020,02,10),
                    Status="Submitted",
                    ExpenseID= new Guid("ECC5F23C-C811-4A14-A0D6-B8732B9A5FEB")
                },
                new UserExpense()
                {
                    UserID= new Guid("E741539C-7606-4C7C-BD85-D273C7D385BB"),
                    ExpenseType="travel",
                    Amount=500,
                    ExpenseDate = new DateTime(2020,10,10),
                    Status="Submitted",
                    ExpenseID= new Guid("E3AE2007-A314-4B0E-A626-BB5BC01DD4DB")
                }

            };
        }
        public bool AddExpense(UserExpense expense)
        {
            expense.ExpenseID = new Guid();
            _userExpenses.ToList().Add(expense);
            return true;
        }

        public IEnumerable<UserExpense> GetAllExpenses()
        {
            return _userExpenses;
        }

        public IEnumerable<UserExpense> GetAllExpensesByUserId(Guid id)
        {
            var expenses = _userExpenses.Where(a => a.UserID == id);
            return expenses.Any() ? expenses : null;
        }

        public bool UpdateExpense(UserExpense expense)
        {
            UserExpense exp = _userExpenses.Where(e => e.ExpenseID == expense.ExpenseID).FirstOrDefault();
            exp.Status = expense.Status;

            return true;
        }
    }
}
