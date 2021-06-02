using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.Common.Dto
{
    public class ExpenseRequest
    {       

        [Required]
        public string UserID { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string ExpenseType { get; set; }

    }
}
