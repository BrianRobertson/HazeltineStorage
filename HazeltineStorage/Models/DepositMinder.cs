using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class DepositMinder
    {
        public int Id { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string PaymentType { get; set; }// paypal, mail, in person.
        public int CustomerId { get; set; }//FK to customer.
        public decimal AmountReceived { get; set; }
        public string Notes { get; set; }
        public DateTime DepositDate { get; set; }
    }
}