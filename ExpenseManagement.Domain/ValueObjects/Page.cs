using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManagement.Domain.ValueObjects
{
    public class Page
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
