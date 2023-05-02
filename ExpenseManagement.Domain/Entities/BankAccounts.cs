using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Domain.Entities
{
    public class BankAccounts : BaseEntity
    {
        public string Title { get; set; }
        public int Type { get; set; }
        public decimal AccountValue { get; set; }

        // Relationships
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
