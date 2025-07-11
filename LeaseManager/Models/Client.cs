using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;

namespace LeaseManager.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Client Name")]

        public string Name { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }
    }
}