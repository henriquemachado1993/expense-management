using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.Entities
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? PathImage { get; set; }

        // Relationships
        public ICollection<Expense> Expenses { get; set; }
    }
}
