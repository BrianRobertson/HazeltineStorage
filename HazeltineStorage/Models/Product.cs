using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string UnitNumber { get; set; }
        public string UnitDescription { get; set; }

        [Display(Name = "Term At Rate")]
        public string TermAtRate { get; set; }

        [Display(Name = "Rental Rate")]
        public decimal RentalRate { get; set; }

        public int ContractId { get; set; }
        [ForeignKey("ContractId")]
        public virtual Contract Contracts { get; set; }
    }
}