using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class PaymentType
    {
        [Key]
        public byte Id { get; set; }
        [Display(Name = "Payment Type")]
        public string PaymentTypeName { get; set; }
    }
}