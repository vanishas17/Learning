using ExpenseApproval.DataAccess.DbContexts;
using ExpenseApproval.DataAccess.Entities;
using ExpenseApproval.DataAccess.Repository;
using ExpenseApproval.Service.Logging;
using ExpenseApproval.Utils.Exceptions;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApproval.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILoggerService _logger;

        public UserService(IRepositoryWrapper repositoryWrapper, ILoggerService logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }
        public User Authenticate(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    throw new BaseException("User or password is incorrect");
                }

                var user = _repositoryWrapper.User.GetByCondition(x => x.Email == email).FirstOrDefault();

                if (user == null)
                {
                    throw new BaseException("User or password is incorrect");
                }

                if (!VerifyPassword(password,user.Password)) return null;

                return user;
            }
            catch(Exception ex)
            {
                Task.Run(() => _logger.Log(LogType.Error, "Authenticate", "", "", ex, "Authenticate failed"));
            }
            throw new BaseException("User or password is incorrect");
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
