using ExpenseManagement.Shared.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.Models.Category
{
    public class CategoryModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PathImage { get; set; }
    }
}
