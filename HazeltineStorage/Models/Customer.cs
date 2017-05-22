using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public CustomerType CustomerType { get; set; }
        public byte CustomerTypeId { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string MainPhone { get; set; }
        public string MobilePhone { get; set; }
        public bool TextNotification { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailNotification { get; set; }
        public bool EmailInvoice { get; set; }
        public decimal CustomerBalance { get; set; }
    }
}