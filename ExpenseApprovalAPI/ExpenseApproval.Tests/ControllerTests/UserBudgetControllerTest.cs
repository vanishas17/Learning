using AutoMapper;
using ExpenseApproval.API.Controllers;
using ExpenseApproval.Service.Budget;
using ExpenseApproval.Tests.MockServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExpenseApproval.Tests.ControllerTests
{
    public class UserBudgetControllerTest
    {
        IUserBudgetService _userBudgetService;
        IMapper _mapper;
        UserBudgetController _userBudgetController;

        public UserBudgetControllerTest()
        {
            _userBudgetService = new UserBudgetServiceMock();
            _userBudgetController = new UserBudgetController(_userBudgetService, _mapper);
        }

        [Fact]
        public void GetBudgetByUserId_MatchOkResult()
        {
            var userID = Guid.NewGuid();

            // act
            var result = _userBudgetController.GetBudgetByUserId(new Guid("85CF0D9D-EB2A-4913-AEA6-E8A661150BC9"), 2020);
            var okResult = result as OkObjectResult;

            // assert
            Assert.Equal(3000, okResult.Value);
        }


    }
}
