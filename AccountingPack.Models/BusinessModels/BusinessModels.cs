using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingPack.Models
{
    /// <summary>
    /// Login User Info
    /// </summary>
    public class LoginUser
    {
        public LoginUser()
        {
        }

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Account Name")]
        public string UserName { get; set; }

        [ForeignKey("Contact")]
        public int? ContactId { get; set; }

        public virtual ContactDetail Contact { get; set; }

        [ForeignKey("Detail")]
        public int? DetailId { get; set; }

        public virtual PersonalDetail Detail { get; set; }

        [ForeignKey("Business")]
        public int? BusinessId { get; set; }

        public virtual Business Business { get; set; }

    }

    /// <summary>
    /// User associates with the business
    /// </summary>
    public class BusinessLoginUser
    {
        public BusinessLoginUser() { }

        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        public string UserName { get; set; }

        [ForeignKey("Id, UserName")]
        public virtual LoginUser LoginUser { get; set; }

        [ForeignKey("Business")]
        public int BusinessId { get; set; }

        public virtual Business Business { get; set; }

    }

    /// <summary>
    /// This domain represents the account of an account in the system. 
    /// </summary>
    public class AccountOwner
    {
        public AccountOwner() { }

        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        public string UserName { get; set; }

        [ForeignKey("Id, UserName")]
        public virtual LoginUser LoginUser { get; set; }

        public int BusinessId { get; set; }

        public virtual Business Business { get; set; }
    }

    /// <summary>
    /// This domain class represents business which account belong to
    /// </summary>
    public class Business
    {

        public Business()
        {
            LoginUsers = new List<LoginUser>();
        }

        public int Id { get; set; }

        [Display(Name = "Business Name")]
        [Required(ErrorMessage = "Required")]
        public string BusinessName { get; set; }

        public virtual AccountOwner Owner { get; set; }

        [ForeignKey("ContactDetail")]
        public int? AddressId { get; set; }

        public virtual ContactDetail Address { get; set; }

        public virtual List<LoginUser> LoginUsers { get; set; }

    }

    /// <summary>
    /// This domain class represent a user and account owner personal details
    /// </summary>
    public class PersonalDetail
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

    }

    /// <summary>
    /// This domain class represents address for a user, business, and business owner
    /// </summary>
    public class ContactDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2 (Optional)")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "City Or State")]
        public string AddressState { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Postal Or Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Phone Number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Email")]
        public string ContactEmail { get; set; }

    }

    /// <summary>
    /// Customer model
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [ForeignKey("Contact")]
        public int? ContactId { get; set; }

        public virtual ContactDetail Contact { get; set; }

    }

    /// <summary>
    /// Supplier model
    /// </summary>
    public class Supplier
    {
        public int Id { get; set; }

        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [ForeignKey("Contact")]
        public int? ContactId { get; set; }

        public virtual ContactDetail Contact { get; set; }

    }
}
