using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaseManager.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Branch Name")]

        public string Name { get; set; }
        public string Location { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        public virtual ICollection<VehicleAllocation> VehicleAllocations { get; set; }
    }
}