using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Status { get; set; }
        public int PrivacyPolicy { get; set; }

        // Relationships
        public ICollection<BankAccounts> BankAccounts { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
