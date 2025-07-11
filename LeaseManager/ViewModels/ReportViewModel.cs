using LeaseManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaseManager.ViewModels
{
    public class ReportViewModel
    {
        public List<ManufacturerCount> SupplierManufacturerCounts { get; set; }
        public List<ManufacturerCount> BranchManufacturerCounts { get; set; }
        public List<ManufacturerCount> ClientManufacturerCounts { get; set; }
        public int TotalManufacturers { get; set; }
        public int TotalSupplierManufacturers { get; set; }
        public int TotalBranchManufacturers { get; set; }
        public int TotalClientManufacturers { get; set; }
    }
}