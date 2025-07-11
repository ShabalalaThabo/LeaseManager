using LeaseManager.Models;
using LeaseManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaseManager.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var reportData = new ReportViewModel
            {
                SupplierManufacturerCounts = db.Vehicles
                    .GroupBy(v => v.Supplier.Name)
                    .Select(g => new ManufacturerCount
                    {
                        Name = g.Key,
                        Count = g.Select(v => v.Make).Distinct().Count()
                    }).ToList(),

                BranchManufacturerCounts = db.VehicleAllocations
                    .GroupBy(va => va.Branch.Name)
                    .Select(g => new ManufacturerCount
                    {
                        Name = g.Key,
                        Count = g.Select(va => va.Vehicle.Make).Distinct().Count()
                    }).ToList(),

                ClientManufacturerCounts = db.Leases
                    .GroupBy(l => l.Client.Name)
                    .Select(g => new ManufacturerCount
                    {
                        Name = g.Key,
                        Count = g.Select(l => l.Vehicle.Make).Distinct().Count()
                    }).ToList()
            };

            // Calculate totals
            reportData.TotalManufacturers = db.Vehicles.Select(v => v.Make).Distinct().Count();
            reportData.TotalSupplierManufacturers = reportData.SupplierManufacturerCounts.Sum(s => s.Count);
            reportData.TotalBranchManufacturers = reportData.BranchManufacturerCounts.Sum(b => b.Count);
            reportData.TotalClientManufacturers = reportData.ClientManufacturerCounts.Sum(c => c.Count);

            return View(reportData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}