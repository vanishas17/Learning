using AutoMapper;
using ExpenseApproval.Utils.Dto;
using ExpenseApproval.DataAccess.Entities;
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
            CreateMap<UserExpense, ExpenseRequest>();
            CreateMap<ExpenseRequest, UserExpense>();
            CreateMap<UserExpense, UpdateExpenseRequest>();
            CreateMap<UserBudget, UserBudgetRequest>();
        }
    }
}
