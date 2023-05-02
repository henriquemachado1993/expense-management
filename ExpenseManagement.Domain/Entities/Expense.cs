using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Domain.Entities
{
    public class Expense : BaseEntity
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int IsPaid { get; set; }

        // Relationships
        public string UserId { get; set; }
        public User User { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
