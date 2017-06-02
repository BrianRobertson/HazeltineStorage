using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class CustomerStatus
    {
        [Key]
        public byte Id { get; set; }

        [Display(Name = "Customer Status")]
        public string StatusDescription { get; set; }

        public IList<Customer> Customer { get; set; }
    }
}