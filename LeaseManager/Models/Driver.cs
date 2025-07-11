using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;

namespace LeaseManager.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Driver Name")]

        public string Name { get; set; }
        [Display(Name = "License Number")]
        public string LicenseNumber { get; set; }
        [Display(Name = "License Expiry")]
        [DataType(DataType.Date)]
        public DateTime LicenseExpiry { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
    }
}