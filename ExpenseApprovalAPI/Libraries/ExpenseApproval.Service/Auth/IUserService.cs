using ExpenseApproval.DataAccess.Entities;

namespace ExpenseApproval.Service.UserService
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
