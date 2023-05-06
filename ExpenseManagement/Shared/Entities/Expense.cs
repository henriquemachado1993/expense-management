using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.Entities
{
    public class Expense : BaseEntity
    {
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Este campo é obrigatório.")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int IsPaid { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public DateTime ExpenseDate { get; set; }

        // Relationships
        public string UserId { get; set; }
        public User User { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Este campo é obrigatório.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
