using ExpenseApproval.API.Helper.Auth;
using ExpenseApproval.Common.Dto;
using ExpenseApproval.Service.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExpenseApproval.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = _userService.Authenticate(request.Username, request.Password);
            if (user == null)
                throw new BaseException("Username or password is incorrect");

            var claims = new List<Claim>();
            claims.Add(new Claim("username", request.Username));

            // Add roles as multiple claims          
            claims.Add(new Claim(ClaimTypes.Role, user.Role));

            // create a new token with token helper and add our claim
            var token = JwtHelper.GetJwtToken(
                request.Username,
                _configuration["JwtToken:SigningKey"],
                _configuration["JwtToken:Issuer"],
                _configuration["JwtToken:Audience"],
                TimeSpan.FromMinutes(Convert.ToDouble(_configuration["JwtToken:TokenTimeoutMinutes"])),
                claims.ToArray());

            var tkn = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expires = token.ValidTo
            };

            return Ok(new { Id = user.UserID, Token = tkn });

        }
    }
}
