﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Models
{
    public class UserBudgetRequest
    {
        public Guid UserID { get; set; }
        public int BudgetYear { get; set; }

    }
}
