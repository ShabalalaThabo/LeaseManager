using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaseManager.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}