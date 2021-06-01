using AutoMapper;
using ExpenseApproval.API.Controllers;
using ExpenseApproval.API.Handlers;
using ExpenseApproval.Service.Budget;
using ExpenseApproval.Service.Expense;
using ExpenseApproval.Tests.MockServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExpenseApproval.Tests.ControllerTests
{
    public class UserExpenseControllerTest
    { 
        UserExpenseController _userExpenseController;
        IUserExpenseService _userExpenseService;
        IUserBudgetService _userBudgetService;
        IExpenseHandler _expenseHandler;
        IMapper _mapper;

        public UserExpenseControllerTest()
        {
            _userExpenseService = new UserExpenseServiceMock();
            _userExpenseController = new UserExpenseController(_userExpenseService, _userBudgetService, _expenseHandler, _mapper);
        }
    
        [Fact]
        public void GetExpenseByUserId_EmptyReturned()
        {
            var userID = Guid.NewGuid();           

            // act
            var result = _userExpenseController.GetAllExpensesByUserId(userID);
            var okResult = result as OkObjectResult;

            // assert
            Assert.Null(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
