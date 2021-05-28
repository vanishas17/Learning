using ExpenseApproval.API.Contracts;
using ExpenseApproval.API.DbContexts;
using ExpenseApproval.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Services
{
    public class UserService : IUserService
    {
        private ExpenseDataContext _context;
        public UserService(ExpenseDataContext context)
        {
            _context = context;
        }
        public User Authenticate(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    return null;
                }

                var user = _context.Users.SingleOrDefault(x => x.Email == email);

                if (user == null) return null;

                if (!VerifyPassword(password)) return null;

                return user;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        private bool VerifyPassword(string password)
        {
            return true;
            //throw new NotImplementedException();
        }
    }
}
