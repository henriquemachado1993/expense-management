using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.Models.Category
{
    public class CategoryIcon
    {
        public List<ItemIcon> Icons { get; set; } = new List<ItemIcon>();
    }

    public class ItemIcon
    {
        public string Name { get; set; }
        public bool Visible { get; set; }
    }
}
