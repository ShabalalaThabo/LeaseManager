namespace LeaseManager.Migrations
{
    using LeaseManager.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LeaseManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LeaseManager.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            // Add suppliers
            var suppliers = new List<Supplier>
        {
            new Supplier { Name = "AutoSource Inc.", ContactPerson = "John Smith", Email = "john@autosource.com", ContactNumber = "555-1001" },
            new Supplier { Name = "Vehicle Depot", ContactPerson = "Sarah Johnson", Email = "sarah@vehicledepot.com", ContactNumber = "555-1002" }
        };
            suppliers.ForEach(s => context.Suppliers.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            // Add branches
            var branches = new List<Branch>
        {
            new Branch { Name = "New York", Location = "123 Main St, NY", ContactNumber = "555-2001" },
            new Branch { Name = "Los Angeles", Location = "456 Sunset Blvd, LA", ContactNumber = "555-2002" }
        };
            branches.ForEach(b => context.Branches.AddOrUpdate(p => p.Name, b));
            context.SaveChanges();

            // Add clients
            var clients = new List<Client>
        {
            new Client { Name = "TechCorp", ContactPerson = "Mike Davis", Email = "mike@techcorp.com", ContactNumber = "555-3001" },
            new Client { Name = "Global Logistics", ContactPerson = "Lisa Wong", Email = "lisa@globallogistics.com", ContactNumber = "555-3002" }
        };
            clients.ForEach(c => context.Clients.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            // Add drivers
            var drivers = new List<Driver>
        {
            new Driver { Name = "Robert Johnson", LicenseNumber = "DL10001", LicenseExpiry = DateTime.Now.AddYears(2), ContactNumber = "555-4001" },
            new Driver { Name = "Emily Chen", LicenseNumber = "DL10002", LicenseExpiry = DateTime.Now.AddYears(3), ContactNumber = "555-4002" }
        };
            drivers.ForEach(d => context.Drivers.AddOrUpdate(p => p.LicenseNumber, d));
            context.SaveChanges();

            // Add vehicles
            var vehicles = new List<Vehicle>
        {
            new Vehicle { Make = "Toyota", Model = "Camry", Year = 2022, VIN = "JT2BF22K1W0123456", Color = "Silver", RegistrationDate = DateTime.Now.AddMonths(-6), SupplierId = 1 },
            new Vehicle { Make = "Ford", Model = "F-150", Year = 2021, VIN = "1FTFW1ET5EF123456", Color = "Black", RegistrationDate = DateTime.Now.AddMonths(-12), SupplierId = 2 },
            new Vehicle { Make = "Honda", Model = "Accord", Year = 2023, VIN = "1HGCV1F13MA123456", Color = "Blue", RegistrationDate = DateTime.Now.AddMonths(-3), SupplierId = 1 }
        };
            vehicles.ForEach(v => context.Vehicles.AddOrUpdate(p => p.VIN, v));
            context.SaveChanges();

            // Add allocations
            var allocations = new List<VehicleAllocation>
        {
            new VehicleAllocation { VehicleId = 1, BranchId = 1, DateFrom = DateTime.Now.AddMonths(-5), Purpose = "Daily leasing" },
            new VehicleAllocation { VehicleId = 2, BranchId = 2, DateFrom = DateTime.Now.AddMonths(-10), Purpose = "Construction support" },
            new VehicleAllocation { VehicleId = 3, BranchId = 1, DateFrom = DateTime.Now.AddMonths(-2), Purpose = "Executive leasing" }
        };
            allocations.ForEach(a => context.VehicleAllocations.Add(a));
            context.SaveChanges();

            // Add leases
            var leases = new List<Lease>
        {
            new Lease { VehicleId = 1, ClientId = 1, DriverId = 1, StartDate = DateTime.Now.AddMonths(-1), EndDate = DateTime.Now.AddMonths(11), MonthlyRate = 450.00m },
            new Lease { VehicleId = 2, ClientId = 2, DriverId = 2, StartDate = DateTime.Now.AddMonths(-2), EndDate = DateTime.Now.AddMonths(10), MonthlyRate = 650.00m },
            new Lease { VehicleId = 3, ClientId = 1, StartDate = DateTime.Now.AddMonths(-1), EndDate = DateTime.Now.AddMonths(11), MonthlyRate = 500.00m }
        };
            leases.ForEach(l => context.Leases.Add(l));
            context.SaveChanges();
        }
    }
}
