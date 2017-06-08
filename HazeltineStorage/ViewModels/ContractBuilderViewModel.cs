using HazeltineStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HazeltineStorage.ViewModels
{
    public class ContractBuilderViewModel
    {
        public Contract Contract { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public ContractBuilderViewModel(Contract contract, Customer customer)
        {
            Contract = contract;
            Customer = customer;
            //Products = new List<Product>();
        }
    }
}