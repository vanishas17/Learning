using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Models
{
    public class UpdateExpenseRequest
    {
        public Guid UserID { get; set; }
        public Guid ExpenseID { get; set; }
        public string ExpenseStatus { get; set; }
    }
}
