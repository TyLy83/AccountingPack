
using AccountingPack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingPack.Data
{
    public class AccPackResource : DbContext
    {

        public AccPackResource(DbContextOptions<AccPackResource> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LoginUser>()
            .HasKey(bu => new { bu.Id, bu.UserName });

            builder.Entity<AccountOwner>()
                        .HasKey(ao => new { ao.Id, ao.UserName });

            builder.Entity<BusinessLoginUser>()
                        .HasKey(bl => new { bl.Id, bl.UserName });

            builder.Entity<Business>()
                        .HasOne(b => b.Owner)
                        .WithOne(o => o.Business)
                        .HasForeignKey<AccountOwner>(o => o.BusinessId);
        }

        #region entities

        // journal entitie
        public DbSet<Journal> Journals { get; set; }

        public DbSet<PurchaseJournal> PurchaseJournal { get; set; }

        public DbSet<SaleJournal> SaleJournal { get; set; }

        // business entities
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<ContactDetail> Contacts { get; set; }

        public DbSet<Business> Businesses { get; set; }

        public DbSet<LoginUser> LoginUsers { get; set; }

        public DbSet<AccountOwner> AccountOwners { get; set; }

        public DbSet<BusinessLoginUser> BusinessLoginUsers { get; set; }

        public DbSet<PersonalDetail> Details { get; set; }

        // accounting entities
        public DbSet<AccountBaseEntitie> AccountEntities { get; set; }

        public DbSet<CurrentAsset> CurrentAssets { get; set; }

        public DbSet<LongTermAsset> LongTermAssets { get; set; }

        public DbSet<CurrentLiability> CurrentLiabilities { get; set; }

        public DbSet<LongTermLiability> LongTermLiabilities { get; set; }

        public DbSet<Depreciation> Drepreciations { get; set; }

        public DbSet<Revenue> Revenues { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Equity> Equities { get; set; }

        public DbSet<Withdrawing> Withdrawings { get; set; }

        public DbSet<Dividen> Dividens { get; set; }

        #endregion

    }
}
