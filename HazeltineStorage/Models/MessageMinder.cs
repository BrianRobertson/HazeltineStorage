using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HazeltineStorage.Models
{
    public class MessageMinder
    {
        public int Id { get; set; }
        public string MessageName { get; set; }
        public string MessageChannel { get; set; }// connect to API table?
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
    }
}