using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string ContractOrCustomerId { get; set; }//Not sure if I should connect with contract or customer.
        public DateTime InvoiceDate { get; set; }
        public string ForMonthOf { get; set; }
        public bool IsPaid { get; set; }
        public Decimal TotalDue { get; set; }
        //Items on invoice. Not sure if I should conect withh products or contract.
    }
}