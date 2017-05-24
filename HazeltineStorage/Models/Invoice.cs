using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [Display(Name = "Invoice Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "For Month Of")]
        public string ForMonthOf { get; set; }

        [Display(Name = "Is Paid?")]
        public bool IsPaid { get; set; }

        [Display(Name = "Total Due")]
        public Decimal TotalDue { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}