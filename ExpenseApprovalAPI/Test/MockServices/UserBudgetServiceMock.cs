using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ExpenseApproval.DataAccess.Entities;
using ExpenseApproval.Service.Budget;

namespace ExpenseApproval.Tests.MockServices
{
    class UserBudgetServiceMock : IUserBudgetService
    {
        private readonly IEnumerable<UserBudget> _userBudgets;
        public UserBudgetServiceMock()
        {
            _userBudgets = new List<UserBudget>()
            {
                new UserBudget(){UserID=new Guid("85CF0D9D-EB2A-4913-AEA6-E8A661150BC9"), BudgetYear=2019, Amount= 5000 },
                new UserBudget(){UserID=new Guid("85CF0D9D-EB2A-4913-AEA6-E8A661150BC9"), BudgetYear=2020, Amount= 5000 },
                new UserBudget(){UserID=new Guid("85CF0D9D-EB2A-4913-AEA6-E8A661150BC9"), BudgetYear=2021, Amount= 5000 },
                new UserBudget(){UserID=new Guid("E741539C-7606-4C7C-BD85-D273C7D385BB"), BudgetYear=2020, Amount= 3000 },
                new UserBudget(){UserID=new Guid("E741539C-7606-4C7C-BD85-D273C7D385BB"), BudgetYear=2021, Amount= 3000 },

            };
        }
        public double GetAvailableBudgetForUser(Guid userId, int budgetYear)
        {
            var amount = Convert.ToDouble(_userBudgets.Where(s => s.UserID == userId && s.BudgetYear == budgetYear).Select(s => s.Amount));

            return amount;
        }

        public int SetBudgetForUser(UserBudget userBudget)
        {
            throw new NotImplementedException();
        }
    }
}
