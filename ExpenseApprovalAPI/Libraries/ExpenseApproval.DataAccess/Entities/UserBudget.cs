using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.DataAccess.Entities
{
    public class UserBudget
    {
        [Required]
        public Guid UserID { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public int BudgetYear { get; set; }
    }
}
