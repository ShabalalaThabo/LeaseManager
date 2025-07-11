using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeaseManager.Models;

namespace LeaseManager.Controllers
{
    public class LeasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Leases
        public ActionResult Index()
        {
            var leases = db.Leases.Include(l => l.Client).Include(l => l.Driver).Include(l => l.Vehicle);
            return View(leases.ToList());
        }

        // GET: Leases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lease lease = db.Leases.Find(id);
            if (lease == null)
            {
                return HttpNotFound();
            }
            return View(lease);
        }

        // GET: Leases/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Make");
            return View();
        }

        // POST: Leases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VehicleId,ClientId,DriverId,StartDate,EndDate,MonthlyRate,Terms")] Lease lease)
        {
            if (ModelState.IsValid)
            {
                db.Leases.Add(lease);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", lease.ClientId);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", lease.DriverId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Make", lease.VehicleId);
            return View(lease);
        }

        // GET: Leases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lease lease = db.Leases.Find(id);
            if (lease == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", lease.ClientId);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", lease.DriverId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Make", lease.VehicleId);
            return View(lease);
        }

        // POST: Leases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleId,ClientId,DriverId,StartDate,EndDate,MonthlyRate,Terms")] Lease lease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", lease.ClientId);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", lease.DriverId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Make", lease.VehicleId);
            return View(lease);
        }

        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lease lease = db.Leases.Find(id);
            db.Leases.Remove(lease);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
