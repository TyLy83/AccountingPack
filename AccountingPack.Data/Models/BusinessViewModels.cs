using AccountingPack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingPack.Data
{
    public class BusinessModel
    {

        public BusinessModel()
        {
            Members = new List<LoginUserModel>();
        }

        public int Id { get; set; }

        [Display(Name = "Business Name")]
        [Required(ErrorMessage = "Enter business name")]
        public string BusinessName { get; set; }

        public int OwnerId { get; set; }

        public string OwnerName { get; set; }

        public AccountOwnerModel Owner { get; set; }

        public int? AddressId { get; set; }

        public ContactModel Address { get; set; }

        public List<LoginUserModel> Members { get; set; }

    }

    public class LoginUserModel
    {
        public int Id { get; set; }

        [Display(Name = "Account Name")]
        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }

        public int? DetailId { get; set; }

        public virtual DetailModel Detail { get; set; }

        public int? ContactId { get; set; }

        public virtual ContactModel Contact { get; set; }

        public int? BusinessId { get; set; }

        public virtual BusinessModel Business { get; set; }

    }

    public class AccountOwnerModel : LoginUserModel { }

    public class DetailModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter date of birth")]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

    }

    public class ContactModel
    {
        public int Id { get; set; }

        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "Enter address line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [Required(ErrorMessage = "Enter address line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "City/State")]
        [Required(ErrorMessage = "Enter address City/State")]
        public string AddressState { get; set; }

        [Display(Name = "Zip/Postal Code")]
        [Required(ErrorMessage = "Enter zip/postal code")]
        public string AddressZipCode { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Enter country")]
        public string Country { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Enter contact number")]
        public string ContactNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter contact email")]
        public string ContactEmail { get; set; }

    }

    public class CustomerModel
    {
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        public int? ContactId { get; set; }

        public ContactModel Contact { get; set; }

    }

    public class SupplierModel
    {
        public int Id { get; set; }

        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        public int? ContactId { get; set; }

        public virtual ContactModel Contact { get; set; }

    }
}
