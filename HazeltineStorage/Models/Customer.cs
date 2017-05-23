using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser{ get; set; }

        public byte CustomerTypeId { get; set; }
        [ForeignKey("CustomerTypeId")]
        public virtual CustomerType CustomerType { get; set; }

        public byte CustomerStatusId { get; set; }
        [ForeignKey("CustomerStatusId")]
        public virtual CustomerStatus CustomerStatus { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }
        [Display(Name = "Main Phone")]
        public string MainPhone { get; set; }
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }
        [Display(Name = "Text Notification")]
        public bool TextNotification { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Email Notification")]
        public bool EmailNotification { get; set; }
        [Display(Name = "Email Invoice")]
        public bool EmailInvoice { get; set; }
        [Display(Name = "Customer Balance")]
        public decimal CustomerBalance { get; set; }
    }
}