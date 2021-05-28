using AutoMapper;
using ExpenseApproval.API.Contracts;
using ExpenseApproval.API.Entities;
using ExpenseApproval.API.Handlers;
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
    public class UserExpenseController : ControllerBase
    {
        private readonly IUserExpenseService _userExpenseService;
        private readonly IUserBudgetService _userBudgetService;
        private readonly IExpenseHandler _expenseHandler;
        private readonly IMapper _mapper;


        public UserExpenseController(
            IUserExpenseService userExpenseService,
            IUserBudgetService userBudgetService,
            IExpenseHandler expenseHandler,
            IMapper mapper
            )
        {
            _userExpenseService = userExpenseService;
            _userBudgetService = userBudgetService;
            _expenseHandler = expenseHandler;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("allexpenses")]
        public IActionResult GetAllExpenses()
        {
            IEnumerable<UserExpense> allExpenses = _userExpenseService.GetAllExpenses();

            return Ok(new { expenses = allExpenses });
        }

        [HttpGet]
        [Route("expenses/{id}")]
        public IActionResult GetAllExpensesByUserId(Guid id)
        {
            IEnumerable<UserExpense> userExpenses = _userExpenseService.GetAllExpensesByUserId(id);

            return Ok(new { expenses = userExpenses });
        }


        [HttpPost]
        [Route("addexpense")]
        public IActionResult AddExpense([FromBody] ExpenseDto expense)
        {
            var _expense = _mapper.Map<UserExpense>(expense);
            try
            {
                var result = _userExpenseService.AddExpense(_expense);
                if (result)
                    return Ok(new { message = "Expense Submitted Successfully" });

                return BadRequest(new { message = "Expense Submission Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Expense Submission Failed" });
            }
        }

        [HttpPost]
        [Route("updateexpense")]
        public IActionResult UpdateExpense([FromBody] UpdateExpenseDto expense)
        {
            var _expense = _mapper.Map<UserExpense>(expense);
            
            try
            {
                var result = _expenseHandler.UpdateExpense(_expense);
                if (result)
                    return Ok(new { message = "Expense Updated Successfully" });

                return BadRequest(new { message = "Expense Update Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Expense Update Failed" });
            }
        }
    }
}
