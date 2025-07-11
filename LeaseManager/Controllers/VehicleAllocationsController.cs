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
    public class VehicleAllocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VehicleAllocations
        public ActionResult Index()
        {
            var vehicleAllocations = db.VehicleAllocations.Include(v => v.Branch).Include(v => v.Vehicle);
            return View(vehicleAllocations.ToList());
        }

        // GET: VehicleAllocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleAllocation vehicleAllocation = db.VehicleAllocations.Find(id);
            if (vehicleAllocation == null)
            {
                return HttpNotFound();
            }
            return View(vehicleAllocation);
        }

        // GET: VehicleAllocations/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Make");
            return View();
        }

        // POST: VehicleAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VehicleId,BranchId,DateFrom,DateTo,Purpose")] VehicleAllocation vehicleAllocation)
        {
            if (ModelState.IsValid)
            {
                db.VehicleAllocations.Add(vehicleAllocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", vehicleAllocation.BranchId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Make", vehicleAllocation.VehicleId);
            return View(vehicleAllocation);
        }

        // GET: VehicleAllocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleAllocation vehicleAllocation = db.VehicleAllocations.Find(id);
            if (vehicleAllocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", vehicleAllocation.BranchId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Make", vehicleAllocation.VehicleId);
            return View(vehicleAllocation);
        }

        // POST: VehicleAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleId,BranchId,DateFrom,DateTo,Purpose")] VehicleAllocation vehicleAllocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleAllocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", vehicleAllocation.BranchId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Make", vehicleAllocation.VehicleId);
            return View(vehicleAllocation);
        }

        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleAllocation vehicleAllocation = db.VehicleAllocations.Find(id);
            db.VehicleAllocations.Remove(vehicleAllocation);
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
