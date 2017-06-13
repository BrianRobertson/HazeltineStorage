using HazeltineStorage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HazeltineStorage.ViewModels
{
    public class ContractBuilderViewModel
    {
        public Contract Contract { get; set; }

        public Customer Customer { get; set; }

        [Display (Name = "Storage Units")]
        public List<StorageUnit> StorageUnits { get; set; }
        //public ContractBuilderViewModel(Contract contract, Customer customer, List<StorageUnit> storageUnits)
        //{
        //    Contract = contract;
        //    Customer = customer;
        //    StorageUnits = storageUnits;
        //}
        public int SelectedStorageUnitId { get; set; }

        public StorageUnit SelectedStorageUnit { get; set; }
    }
}