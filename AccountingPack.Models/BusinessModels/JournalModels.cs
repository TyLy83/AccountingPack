using AccountingPack.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingPack.Models
{
    /// <summary>
    /// Journal model
    /// </summary>
    public class Journal
    {

        public Journal() { }

        public Journal(int id, string note, int? accountToDebitId, int? accountToCreditId, JournalCategory category)
        {
            Id = id;
            Note = note;
            AccountToDebitId = accountToDebitId;
            AccountToCreditId = accountToCreditId;
            Category = category;
        }

        [Key]
        public int Id { get; set; }

        public string Note { get; set; }

        public decimal Balance { get; set; }

        public JournalCategory Category { get; set; }

        public DateTime CreateOn { get; set; }

        public int CreateBy { get; set; }

        [ForeignKey("AccountToDebit")]
        public int? AccountToDebitId { get; set; }

        public virtual AccountBaseEntitie AccountToDebit { get; set; }

        [ForeignKey("AccountToCredits")]
        public int? AccountToCreditId { get; set; }
        public virtual AccountBaseEntitie AccountToCredit { get; set; }

    }

    /// <summary>
    /// purchase journal
    /// </summary>
    public class PurchaseJournal : Journal
    {

        public PurchaseJournal(int id, string note, int? accountToDebitId, int? accountToCreditId, DateTime purchaseDate, string supInvNumber, int supplierId)
            : base(id, note, accountToDebitId, accountToCreditId, JournalCategory.Purchases)
        {
            PurchaseDate = purchaseDate;
            SupInvNumber = supInvNumber;
            SupplierId = supplierId;
        }

        public DateTime PurchaseDate { get; set; }

        public string SupInvNumber { get; set; }

        public int PurNumber { get; set; }

        [ForeignKey("Customer")]
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

    }

    /// <summary>
    /// sale journal
    /// </summary>
    public class SaleJournal : Journal
    {

        public SaleJournal(int id, string note, int? accountToDebitId, int? accountToCreditId, DateTime invoiceDate, int customerId)
                        : base(id, note, accountToDebitId, accountToCreditId, JournalCategory.Purchases)
        {
            InvoiceDate = invoiceDate;
            CustomerId = customerId;
        }

        public DateTime InvoiceDate { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

    }
}
