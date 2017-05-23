using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }//FK of Customer.
        public DateTime LogDate { get; set; }
        public string MessageType { get; set; }//from message minder.
        public string Notes { get; set; }
        public string UserId { get; set; }// the person logged into the software.
    }
}