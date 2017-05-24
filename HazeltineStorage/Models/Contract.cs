using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class Contract
    {
        public Contract()
        {
            Products = new List<Product>();
        }
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Day of Month Due")]
        [Range(1,31)]
        public int DayOfMonthDue { get; set; }

        [Display(Name = "Day of Month Grace Period Ends")]
        [Range(1,31)]
        public int DayOfMonthGracePeriodEnds { get; set; }
        
        [Display(Name = "Contract Total")]
        public decimal ContractTotal { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}