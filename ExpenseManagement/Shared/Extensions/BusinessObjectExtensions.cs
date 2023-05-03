using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Shared.ValueObjects;

namespace ExpenseManagement.Shared.Extensions
{
    public static class BusinessObjectExtensions
    {
            public static BusinessObject<T> AsBusinessObject<T>(this T model) => new BusinessObject<T>(model);
            public static BusinessObject<T> AsBusinessObject<T>(this T model, ClaimsIdentity identity) => new BusinessObject<T>(identity,  model);
    }
}
