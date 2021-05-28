using ExpenseApproval.API.Contracts;
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
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Authenticate([FromBody] AuthRequest request)
        {
            try
            {
                var user = _userService.Authenticate(request.Username, request.Password);
                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                var token = "";
                
                return Ok(new { Id = user.UserID, Token = token });

            } 
            catch(Exception ex)
            {
                return BadRequest(new { message = "Authentication Failed" });
            }
        }
    }
}
