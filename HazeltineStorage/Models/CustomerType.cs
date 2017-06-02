using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class CustomerType
    {
        [Key]
        public byte Id { get; set; }

        [Display(Name = "Customer Type")]
        public string TypeDescription { get; set; }

        public IList<Customer> Customer { get; set; }
    }
}