using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaseManager.Models
{
    public class VehicleAllocation
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Display(Name = "Date From")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Date To")]
        [DataType(DataType.Date)]
        public DateTime? DateTo { get; set; }
        public string Purpose { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Branch Branch { get; set; }
    }
}