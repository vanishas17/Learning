using ExpenseApproval.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Contracts
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
