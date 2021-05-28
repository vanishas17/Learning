using AutoMapper;
using ExpenseApproval.API.Entities;
using ExpenseApproval.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExpenseApproval.API.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserExpense, ExpenseDto>();
            CreateMap<UserExpense, UpdateExpenseDto>();
            CreateMap<UserBudget, UserBudgetDto>();
        }
    }
}
