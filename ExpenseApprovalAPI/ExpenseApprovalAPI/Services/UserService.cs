using ExpenseApproval.API.Contracts;
using ExpenseApproval.API.DbContexts;
using ExpenseApproval.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Services
{
    public class UserService : IUserService
    {
        private readonly ExpenseDataContext _context;
        private readonly ILoggerService _logger;

        public UserService(ExpenseDataContext context, ILoggerService logger)
        {
            _context = context;
            _logger = logger;
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

                if (!VerifyPassword(password,user.Password)) return null;

                return user;
            }
            catch(Exception ex)
            {
                Task.Run(() => _logger.Log(LogType.Error, "Authenticate", "", "", ex, "Authenticate failed"));
            }
            return null;
        }

        private bool VerifyPassword(string password,string hashPassword)
        {
            StringBuilder hash = new StringBuilder();
            var md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(password));
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            if (string.Compare( hash.ToString(), hashPassword,true) == 0 )
                return true;
            return false;
        }
    }
}
