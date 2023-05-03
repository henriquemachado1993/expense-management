using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManagement.Shared.Entities
{
    public class WaitingList : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
    }
}
