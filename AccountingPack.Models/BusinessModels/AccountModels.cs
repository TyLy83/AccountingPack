using AccountingPack.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingPack.Models
{
    /// <summary>
    /// this domain represent the base accounting entitie
    /// which will be implemented to create several accounting entitie
    /// </summary>
    public class AccountBaseEntitie
    {

        public AccountBaseEntitie() { }

        public AccountBaseEntitie(int id, string name, int businessId, AccountCategory cat)
        {
            Id = id;
            Name = name;
            BusinessId = businessId;
            Category = cat;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        public AccountCategory Category { get; set; }

        #region navigation

        [ForeignKey("Business")]
        public int? BusinessId { get; set; }

        public virtual Business Business { get; set; }

        #endregion

    }

    /// <summary>
    /// this class represents business current assets
    /// </summary>
    public class CurrentAsset : AccountBaseEntitie
    {

        public CurrentAsset()
        {
            Category = AccountCategory.CurrentAssets;
        }

        public CurrentAsset(int id, string name, int businessId)
            : base(id, name, businessId, AccountCategory.CurrentAssets)
        {

        }

    }

    /// <summary>
    /// This concrete class represents business long-term assets
    /// </summary>
    public class LongTermAsset : AccountBaseEntitie
    {

        public LongTermAsset() : base() { }

        public LongTermAsset(int id, string name, int businessId, int? accDepId)
            : base(id, name, businessId, AccountCategory.LongTermAssets)
        {

            AccDepId = accDepId;

        }

        [ForeignKey("Depreciation")]
        public int? AccDepId { get; set; }

        public virtual Depreciation Depreciation { get; set; }

    }

    /// <summary>
    /// this concrete class represents long-term asset accumulated depreciation
    /// </summary>
    public class Depreciation : AccountBaseEntitie
    {

        public Depreciation() : base() { }

        public Depreciation(int id, string name, int businessId)
            : base(id, name, businessId, AccountCategory.Depreciations)
        {

        }

    }

    /// <summary>
    /// This concrete class represents business current liabilities
    /// </summary>
    public class CurrentLiability : AccountBaseEntitie
    {

        public CurrentLiability(): base()
        {

        }

        public CurrentLiability(int id, string name, int businessId)
            : base(id, name, businessId, AccountCategory.CurrentLiabilities)
        {

        }

    }

    /// <summary>
    /// This concrete class represents business long-term debts
    /// </summary>
    public class LongTermLiability : AccountBaseEntitie
    {

        public LongTermLiability(): base() { }

        public LongTermLiability(int id, string name, int businessId)
            : base(id, name, businessId, AccountCategory.LongTermLiabilities)
        {

        }

    }

    /// <summary>
    /// Business'owner equity
    /// </summary>
    public class Equity : AccountBaseEntitie
    {

        public Equity() : base() { }

        public Equity(int id, string name, int businessId)
            : base(id, name, businessId, AccountCategory.Equities)
        {

        }

    }

    /// <summary>
    /// Business expenses
    /// </summary>
    public class Expense : AccountBaseEntitie
    {

        public Expense() : base() { }

        public Expense(int id, string name, int businessId)
            : base(id, name, businessId, AccountCategory.Expenses)
        {

        }

    }

    /// <summary>
    /// Business revenue
    /// </summary>
    public class Revenue : AccountBaseEntitie
    {

        public Revenue() : base() { }

        public Revenue(int id, string name, int businessId)
            : base(id, name, businessId, AccountCategory.Revenues)
        {

        }

    }

    /// <summary>
    /// Owner withdrawing
    /// </summary>
    public class Withdrawing : AccountBaseEntitie
    {
        public Withdrawing() : base() { }

        public Withdrawing(int id, string name, int businessId)
            : base(id, name, businessId, AccountCategory.Withdrawing)
        {

        }
    }

    /// <summary>
    /// Dividens
    /// </summary>
    public class Dividen : AccountBaseEntitie
    {

        public Dividen() : base() { }

        public Dividen(int id, string name, int businessId)
            : base(id, name, businessId, AccountCategory.Dividens)
        {

        }
    }
}
