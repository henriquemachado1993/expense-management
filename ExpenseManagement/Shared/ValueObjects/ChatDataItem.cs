using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.ValueObjects
{
    public class DataItem<T>
    {
        public string Key { get; set; }
        public T Value { get; set; }
    }
}
