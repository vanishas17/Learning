﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Models
{
    public class UserBudgetDto
    {
        public Guid UserID { get; set; }
        public int BudgetYear { get; set; }

        public double Amount { get; set; }
    }
}
