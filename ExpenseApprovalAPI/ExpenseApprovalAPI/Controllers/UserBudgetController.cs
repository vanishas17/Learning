using AutoMapper;
using ExpenseApproval.API.Contracts;
using ExpenseApproval.API.Entities;
using ExpenseApproval.API.Models;
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
        public IActionResult GetBudgetByUserId([FromBody] UserBudgetDto userBudget)
        {
            var budget = _mapper.Map<UserBudget>(userBudget);
            try
            {
                double amount = _userBudgetService.GetBudgetForUser(budget);

                return Ok(new { Budget = amount });
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = "Error while fetching budget for user" });
            }
        }
    }
}
