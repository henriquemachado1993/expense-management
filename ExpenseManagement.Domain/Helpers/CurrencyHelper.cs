using System;
using System.Globalization;

namespace ExpenseManagement.Domain.Helpers
{
    /// <summary>
    /// Currency help class
    /// </summary>
    public static class CurrencyHelper
    {
        /// <summary>
        /// Pick up currency symbol
        /// </summary>
        /// <returns>Returns the currency symbol</returns>
        public static string GetSymbol(string currencyCode)
        {
            switch (currencyCode)
            {
                case "BRL": { return new RegionInfo("BR").CurrencySymbol; }
                case "USD": { return new RegionInfo("US").CurrencySymbol; }
                case "EUR": { return new RegionInfo("FR").CurrencySymbol; }
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Get the value according to the type of currency
        /// </summary>       
        /// <returns>Retorna valor formatado de acordo com a moeda</returns>
        public static string FormatCurrency(decimal value, string currencyCode)
        {
            switch (currencyCode)
            {
                case "BRL": { return value.ToString("c", CultureInfo.GetCultureInfo("pt-BR")); }
                case "USD": { return value.ToString("c", CultureInfo.GetCultureInfo("en-US")); }
                case "EUR":
                    {
                        var culture = new CultureInfo("fr-FR");
                        culture.NumberFormat.CurrencyPositivePattern = 0;
                        culture.NumberFormat.CurrencyNegativePattern = 2;
                        culture.NumberFormat.CurrencyDecimalSeparator = CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator;
                        return value.ToString("c", culture);
                    }
                default:
                    return string.Empty;
            }
        }
    }
}
