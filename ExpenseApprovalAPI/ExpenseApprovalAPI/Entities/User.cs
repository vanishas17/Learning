﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Entities
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
       
        public string Password { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
