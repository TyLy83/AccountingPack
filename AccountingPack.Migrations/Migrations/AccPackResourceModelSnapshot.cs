using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AccountingPack.Data;
using AccountingPack.Enums;

namespace AccountingPack.Migrations.Migrations
{
    [DbContext(typeof(AccPackResource))]
    partial class AccPackResourceModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccountingPack.Models.AccountBaseEntitie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BusinessId");

                    b.Property<int>("Category");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("AccountEntities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AccountBaseEntitie");
                });

            modelBuilder.Entity("AccountingPack.Models.AccountOwner", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("UserName");

                    b.Property<int>("BusinessId");

                    b.HasKey("Id", "UserName");

                    b.HasIndex("BusinessId")
                        .IsUnique();

                    b.ToTable("AccountOwners");
                });

            modelBuilder.Entity("AccountingPack.Models.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<string>("BusinessName");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("AccountingPack.Models.BusinessLoginUser", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("UserName");

                    b.Property<int>("BusinessId");

                    b.HasKey("Id", "UserName");

                    b.HasIndex("BusinessId");

                    b.ToTable("BusinessLoginUsers");
                });

            modelBuilder.Entity("AccountingPack.Models.ContactDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .IsRequired();

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressState")
                        .IsRequired();

                    b.Property<string>("ContactEmail")
                        .IsRequired();

                    b.Property<string>("ContactNumber")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("AccountingPack.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContactId");

                    b.Property<string>("CustomerName");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AccountingPack.Models.Journal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountToCreditId");

                    b.Property<int?>("AccountToDebitId");

                    b.Property<decimal>("Balance");

                    b.Property<int>("Category");

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateOn");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Note");

                    b.HasKey("Id");

                    b.HasIndex("AccountToCreditId");

                    b.HasIndex("AccountToDebitId");

                    b.ToTable("Journals");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Journal");
                });

            modelBuilder.Entity("AccountingPack.Models.LoginUser", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("UserName");

                    b.Property<int?>("BusinessId");

                    b.Property<int?>("ContactId");

                    b.Property<int?>("DetailId");

                    b.HasKey("Id", "UserName");

                    b.HasIndex("BusinessId");

                    b.HasIndex("ContactId");

                    b.HasIndex("DetailId");

                    b.ToTable("LoginUsers");
                });

            modelBuilder.Entity("AccountingPack.Models.PersonalDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.HasKey("Id");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("AccountingPack.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContactId");

                    b.Property<string>("SupplierName");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("AccountingPack.Models.CurrentAsset", b =>
                {
                    b.HasBaseType("AccountingPack.Models.AccountBaseEntitie");


                    b.ToTable("CurrentAsset");

                    b.HasDiscriminator().HasValue("CurrentAsset");
                });

            modelBuilder.Entity("AccountingPack.Models.CurrentLiability", b =>
                {
                    b.HasBaseType("AccountingPack.Models.AccountBaseEntitie");


                    b.ToTable("CurrentLiability");

                    b.HasDiscriminator().HasValue("CurrentLiability");
                });

            modelBuilder.Entity("AccountingPack.Models.Depreciation", b =>
                {
                    b.HasBaseType("AccountingPack.Models.AccountBaseEntitie");


                    b.ToTable("Depreciation");

                    b.HasDiscriminator().HasValue("Depreciation");
                });

            modelBuilder.Entity("AccountingPack.Models.Dividen", b =>
                {
                    b.HasBaseType("AccountingPack.Models.AccountBaseEntitie");


                    b.ToTable("Dividen");

                    b.HasDiscriminator().HasValue("Dividen");
                });

            modelBuilder.Entity("AccountingPack.Models.Equity", b =>
                {
                    b.HasBaseType("AccountingPack.Models.AccountBaseEntitie");


                    b.ToTable("Equity");

                    b.HasDiscriminator().HasValue("Equity");
                });

            modelBuilder.Entity("AccountingPack.Models.Expense", b =>
                {
                    b.HasBaseType("AccountingPack.Models.AccountBaseEntitie");


                    b.ToTable("Expense");

                    b.HasDiscriminator().HasValue("Expense");
                });

            modelBuilder.Entity("AccountingPack.Models.LongTermAsset", b =>
                {
                    b.HasBaseType("AccountingPack.Models.AccountBaseEntitie");

                    b.Property<int?>("AccDepId");

                    b.HasIndex("AccDepId");

                    b.ToTable("LongTermAsset");

                    b.HasDiscriminator().HasValue("LongTermAsset");
                });

            modelBuilder.Entity("AccountingPack.Models.LongTermLiability", b =>
                {
                    b.HasBaseType("AccountingPack.Models.AccountBaseEntitie");


                    b.ToTable("LongTermLiability");

                    b.HasDiscriminator().HasValue("LongTermLiability");
                });

            modelBuilder.Entity("AccountingPack.Models.Revenue", b =>
                {
                    b.HasBaseType("AccountingPack.Models.AccountBaseEntitie");


                    b.ToTable("Revenue");

                    b.HasDiscriminator().HasValue("Revenue");
                });

            modelBuilder.Entity("AccountingPack.Models.Withdrawing", b =>
                {
                    b.HasBaseType("AccountingPack.Models.AccountBaseEntitie");


                    b.ToTable("Withdrawing");

                    b.HasDiscriminator().HasValue("Withdrawing");
                });

            modelBuilder.Entity("AccountingPack.Models.PurchaseJournal", b =>
                {
                    b.HasBaseType("AccountingPack.Models.Journal");

                    b.Property<int>("PurNumber");

                    b.Property<DateTime>("PurchaseDate");

                    b.Property<string>("SupInvNumber");

                    b.Property<int>("SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("PurchaseJournal");

                    b.HasDiscriminator().HasValue("PurchaseJournal");
                });

            modelBuilder.Entity("AccountingPack.Models.SaleJournal", b =>
                {
                    b.HasBaseType("AccountingPack.Models.Journal");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("InvoiceDate");

                    b.HasIndex("CustomerId");

                    b.ToTable("SaleJournal");

                    b.HasDiscriminator().HasValue("SaleJournal");
                });

            modelBuilder.Entity("AccountingPack.Models.AccountBaseEntitie", b =>
                {
                    b.HasOne("AccountingPack.Models.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId");
                });

            modelBuilder.Entity("AccountingPack.Models.AccountOwner", b =>
                {
                    b.HasOne("AccountingPack.Models.Business", "Business")
                        .WithOne("Owner")
                        .HasForeignKey("AccountingPack.Models.AccountOwner", "BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountingPack.Models.LoginUser", "LoginUser")
                        .WithMany()
                        .HasForeignKey("Id", "UserName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountingPack.Models.Business", b =>
                {
                    b.HasOne("AccountingPack.Models.ContactDetail", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("AccountingPack.Models.BusinessLoginUser", b =>
                {
                    b.HasOne("AccountingPack.Models.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountingPack.Models.LoginUser", "LoginUser")
                        .WithMany()
                        .HasForeignKey("Id", "UserName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountingPack.Models.Customer", b =>
                {
                    b.HasOne("AccountingPack.Models.ContactDetail", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("AccountingPack.Models.Journal", b =>
                {
                    b.HasOne("AccountingPack.Models.AccountBaseEntitie", "AccountToCredit")
                        .WithMany()
                        .HasForeignKey("AccountToCreditId");

                    b.HasOne("AccountingPack.Models.AccountBaseEntitie", "AccountToDebit")
                        .WithMany()
                        .HasForeignKey("AccountToDebitId");
                });

            modelBuilder.Entity("AccountingPack.Models.LoginUser", b =>
                {
                    b.HasOne("AccountingPack.Models.Business", "Business")
                        .WithMany("LoginUsers")
                        .HasForeignKey("BusinessId");

                    b.HasOne("AccountingPack.Models.ContactDetail", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("AccountingPack.Models.PersonalDetail", "Detail")
                        .WithMany()
                        .HasForeignKey("DetailId");
                });

            modelBuilder.Entity("AccountingPack.Models.Supplier", b =>
                {
                    b.HasOne("AccountingPack.Models.ContactDetail", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("AccountingPack.Models.LongTermAsset", b =>
                {
                    b.HasOne("AccountingPack.Models.Depreciation", "Depreciation")
                        .WithMany()
                        .HasForeignKey("AccDepId");
                });

            modelBuilder.Entity("AccountingPack.Models.PurchaseJournal", b =>
                {
                    b.HasOne("AccountingPack.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountingPack.Models.SaleJournal", b =>
                {
                    b.HasOne("AccountingPack.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
