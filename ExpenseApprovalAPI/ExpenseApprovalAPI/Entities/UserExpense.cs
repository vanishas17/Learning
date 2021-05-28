using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Entities
{
    public class UserExpense
    {
        [Key]
        public Guid ExpenseID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string ExpenseType { get; set; }

        [Required]
         public string Status { get; set; }
     }
}
