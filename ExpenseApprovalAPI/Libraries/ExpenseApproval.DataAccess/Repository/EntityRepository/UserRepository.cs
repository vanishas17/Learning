
using ExpenseApproval.DataAccess.DbContexts;
using ExpenseApproval.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseApproval.DataAccess.Repository.EntityRepository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ExpenseDataContext context) : base(context)
        {
        }
    }
}
