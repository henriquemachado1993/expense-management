using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.Entities
{
    public class BankAccounts : BaseEntity
    {
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Title { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Este campo é obrigatório.")]
        public int Type { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public decimal AccountValue { get; set; }

        // Relationships
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
