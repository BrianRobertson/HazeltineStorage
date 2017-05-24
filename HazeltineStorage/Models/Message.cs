using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Message Type")]
        public string MessageType { get; set; }

        [Display(Name = "Message Channel")]
        public string MessageChannel { get; set; }// connect to API class?

        [Display(Name = "Message Subject")]
        public string MessageSubject { get; set; }

        [Display(Name = "Message Content")]
        public string MessageContent { get; set; }
    }
}