using AutoMapper;
using ExpenseApproval.API.Helper.Exception;
using ExpenseApproval.Service.Budget;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionFilter))]
    public class UserBudgetController : ControllerBase
    {
        private readonly IUserBudgetService _userBudgetService;
        private readonly IMapper _mapper;

        public UserBudgetController(IUserBudgetService userBudgetService,
            IMapper mapper)
        {
            _userBudgetService = userBudgetService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getbudget")]
        [Authorize]
        public IActionResult GetBudgetByUserId(Guid userId,int budgetYear)
        {

                double amount = _userBudgetService.GetAvailableBudgetForUser(userId,budgetYear);
                return Ok(amount);
        }
    }
}
