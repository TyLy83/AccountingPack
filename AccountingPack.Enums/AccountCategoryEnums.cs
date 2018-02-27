using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using System.Reflection;


namespace AccountingPack.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum AccountCategory
    {
        [Display(Name = "Current Assets", Description = "Current Assets")]
        CurrentAssets,
        [Display(Name = "Fixed Assets", Description = "Fixed Assets")]
        LongTermAssets,
        [Display(Name = "Current Liabilities", Description = "Current Liabilities")]
        CurrentLiabilities,
        [Display(Name = "Long-term Debts", Description = "Long-term Debts")]
        LongTermLiabilities,
        [Display(Name = "Equities", Description = "Owners' Equity")]
        Equities,
        [Display(Name = "Expenses", Description = "Expenses")]
        Expenses,
        [Display(Name = "Revenues", Description = "Revenues")]
        Revenues,
        [Display(Name = "Depreciations", Description = "Depreciations")]
        Depreciations,
        [Display(Name = "Withdrawing", Description = "Withdrawing")]
        Withdrawing,
        [Display(Name = "Dividens", Description = "Dividens")]
        Dividens
    }

    public static class EnumExtension
    {

        public static string Description(this Enum value)
        {
            // get attributes  
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(false);

            // Description is in a hidden Attribute class called DisplayAttribute
            // Not to be confused with DisplayNameAttribute
            dynamic displayAttribute = null;

            if (attributes.Any())
            {
                displayAttribute = attributes.ElementAt(0);
            }

            // return description
            return displayAttribute?.Description ?? "Description Not Found";
        }

    }
}
