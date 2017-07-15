using HazeltineStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HazeltineStorage.ViewModels
{
    public class CustomerPaymentViewModel
    {
        public Customer Customer { get; set; }

        public Payment Payment { get; set; }
    }
}