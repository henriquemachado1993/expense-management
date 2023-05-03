using ExpenseManagement.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.Helpers
{
    public static class AlertHelper
    {
        public static void AddSuccess(List<MessageResult> alert, string message, string? typeCustom = null)
        {
            if(alert == null)
                alert = new List<MessageResult>();

            alert.Add(new MessageResult() { Message = message, TypeCustom = "success" });
        }

        public static void AddError(List<MessageResult> alert, string message, string? typeCustom = null)
        {
            if (alert == null)
                alert = new List<MessageResult>();

            alert.Add(new MessageResult() { Message = message, TypeCustom = "danger" });
        }
    }
}
