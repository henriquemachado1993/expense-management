using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseManagement.Shared.Enums
{
    public enum Status
    {
        [Display(Name = "Inativo")]
        Inactive = 0,
        [Display(Name = "Ativo")]
        Active = 1
    }
}
