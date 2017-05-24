using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class ActivityLog
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [Display(Name = "Log Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LogDate { get; set; }

        public int MessageId { get; set; }
        [ForeignKey("MessageId")]
        public virtual Message MessageType { get; set; }

        public string Notes { get; set; }

        public string UserId { get; set; }// the person logged into the software doing the sending, not the customer.
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}