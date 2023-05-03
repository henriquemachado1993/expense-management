using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManagement.Shared.Helpers
{
    public static class PermissionHelper
    {
        public const string Admin = nameof(Admin);
        public const string Operator = nameof(Operator);
        public const string User = nameof(User);

        public static List<string> GetAll()
        {
            return new List<string>() {
                Admin,
                Operator,
                User
            };
        }

        public static string GetDescription(string id)
        {
            switch (id)
            {
                case "Admin": { return "Administrador"; }
                case "Operator": { return "Operador"; }
                case "User": { return "Usuário"; }
                default:
                    return string.Empty;
            }
        }
    }
}
