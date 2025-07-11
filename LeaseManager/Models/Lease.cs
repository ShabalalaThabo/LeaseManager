using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaseManager.Models
{
    public class Lease
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        [Display(Name = "Driver")]
        public int? DriverId { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Monthly Rate")]
        public decimal MonthlyRate { get; set; }
        public string Terms { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Client Client { get; set; }
        public virtual Driver Driver { get; set; }
    }
}