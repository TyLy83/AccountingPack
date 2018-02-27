using System;
using System.ComponentModel.DataAnnotations;

namespace AccountingPack.Enums
{
    public enum JournalCategory
    {
        [Display(Name = "Sale journals", Description = "Sales")]
        Sales,
        [Display(Name = "Purchase journals", Description = "Purchase")]
        Purchases,
        [Display(Name = "Payment journals", Description = "Payments")]
        Payments,
        [Display(Name = "General journals", Description = "Generals")]
        Generals
    }
}
