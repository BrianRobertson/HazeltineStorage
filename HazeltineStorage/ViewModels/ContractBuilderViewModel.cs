using HazeltineStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HazeltineStorage.ViewModels
{
    public class ContractBuilderViewModel
    {
        public Customer Customer { get; set; }
        public Contract Contract { get; set; }
        public List<Product> Products { get; set; }
    }
}