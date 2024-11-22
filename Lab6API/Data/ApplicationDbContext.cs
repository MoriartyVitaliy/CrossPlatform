using Lab6API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Http;


namespace Lab6API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CustomerStatus> CustomerStatuses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PartSupplier> PartSuppliers { get; set; }
        public DbSet<PartGroup> PartGroups { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<PartMaker> PartMakers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarManufacturer> CarManufacturers { get; set; }
        public DbSet<PartForCar> PartsForCars { get; set; }
        public DbSet<PartInOrder> PartsInOrders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarManufacturer>()
                .HasKey(cm => cm.CarManufacturerNr);

            modelBuilder.Entity<CustomerStatus>()
                .HasKey(cm => cm.StatusCode);

            modelBuilder.Entity<PartMaker>()
                .HasKey(pm => pm.PartMakerCode);

            modelBuilder.Entity<Brand>()
                .HasKey(b => b.BrandID);

            modelBuilder.Entity<Supplier>()
                .HasKey(s => s.SupplierNr);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerID);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderID);

            modelBuilder.Entity<Part>()
                .HasKey(p => p.PartID);

            modelBuilder.Entity<PartGroup>()
                .HasKey(k => k.PartGroupID);

            modelBuilder.Entity<PartSupplier>()
                .HasKey(ps => ps.PartSupplierID);

            modelBuilder.Entity<Car>()
                .HasKey(c => c.CarID);

            modelBuilder.Entity<PartInOrder>()
                .HasKey(c => c.PartInOrderID);

            modelBuilder.Entity<PartForCar>()
                .HasKey(pfc => new { pfc.PartID, pfc.CarID }); // PF FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF for me

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.CustomerStatus)
                .WithMany(cs => cs.Customers)
                .HasForeignKey(c => c.StatusCode);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID);


            modelBuilder.Entity<Part>()
                .HasOne(p => p.PartGroup)
                .WithMany(pg => pg.Parts)
                .HasForeignKey(p => p.PartGroupID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false); // Возможно, что деталь не обязательно должна быть в группе

            modelBuilder.Entity<Part>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Parts)
                .HasForeignKey(p => p.BrandID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Part>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.SuppliedParts)
                .HasForeignKey(p => p.MainSupplierNr)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Part>()
                .HasOne(p => p.PartMaker)
                .WithMany(pm => pm.Parts)
                .HasForeignKey(p => p.PartMakerCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PartSupplier>()
                .HasOne(ps => ps.Part)
                .WithMany(p => p.PartSuppliers)
                .HasForeignKey(ps => ps.PartID);

            modelBuilder.Entity<PartSupplier>()
                .HasOne(ps => ps.Supplier)
                .WithMany(s => s.PartSuppliers)
                .HasForeignKey(ps => ps.SupplierID);
            
            modelBuilder.Entity<Car>()
                .HasOne(c => c.CarManufacturer)
                .WithMany(cm => cm.Cars)
                .HasForeignKey(c => c.CarManufacturerNr);

            modelBuilder.Entity<PartForCar>()
                .HasOne(pfc => pfc.Part)
                .WithMany(p => p.PartsForCars)
                .HasForeignKey(pfc => pfc.PartID);

            modelBuilder.Entity<PartForCar>()
                .HasOne(pfc => pfc.Car)
                .WithMany(c => c.PartsForCars)
                .HasForeignKey(pfc => pfc.CarID);

            modelBuilder.Entity<PartInOrder>()
                .HasOne(pio => pio.Order)
                .WithMany(o => o.PartsInOrders)
                .HasForeignKey(pio => pio.OrderID);

            modelBuilder.Entity<PartInOrder>()
                .HasOne(pio => pio.PartSupplier)
                .WithMany(o => o.PartInOrders)
                .HasForeignKey(pio => pio.PartSupplierID);


            // Додавання даних для Brand
            var brands = new[]
            {
        new Brand { BrandID = Guid.NewGuid().ToString(), BrandName = "Toyota", BrandDetails = "Details about Toyota" },
        new Brand { BrandID = Guid.NewGuid().ToString(), BrandName = "Honda", BrandDetails = "Details about Honda" },
    };
            modelBuilder.Entity<Brand>().HasData(brands);

            // Додавання даних для PartGroup
            var partGroups = new[]
            {
        new PartGroup { PartGroupID = Guid.NewGuid().ToString(), PartGroupName = "Engine" },
        new PartGroup { PartGroupID = Guid.NewGuid().ToString(), PartGroupName = "Brakes" },
    };
            modelBuilder.Entity<PartGroup>().HasData(partGroups);

            // Додавання даних для CarManufacturer
            var manufacturers = new[]
            {
        new CarManufacturer { CarManufacturerNr = Guid.NewGuid().ToString(), CarManufacturerName = "Toyota" },
        new CarManufacturer { CarManufacturerNr = Guid.NewGuid().ToString(), CarManufacturerName = "Honda" },
    };
            modelBuilder.Entity<CarManufacturer>().HasData(manufacturers);

            // Додавання даних для CustomerStatus
            var statuses = new[]
            {
        new CustomerStatus { StatusCode = 1, StatusDescription = "Active" },
        new CustomerStatus { StatusCode = 2, StatusDescription = "Inactive" },
    };
            modelBuilder.Entity<CustomerStatus>().HasData(statuses);

            // Додавання даних для Supplier
            var suppliers = new[]
            {
        new Supplier
        {
            SupplierNr = Guid.NewGuid().ToString(),
            SupplierName = "Supplier A",
            StreetAddress = "123 Main St",
            Town = "Townsville",
            County = "County",
            Postcode = "12345",
            Phone = "123-456-7890",
            OtherDetails = "High quality parts"
        },
        new Supplier
        {
            SupplierNr = Guid.NewGuid().ToString(),
            SupplierName = "Supplier B",
            StreetAddress = "456 Side St",
            Town = "Cityville",
            County = "Region",
            Postcode = "67890",
            Phone = "987-654-3210",
            OtherDetails = "Affordable prices"
        },
    };
            modelBuilder.Entity<Supplier>().HasData(suppliers);

            // Додавання даних для Part
            var parts = new[]
            {
        new Part
        {
            PartID = Guid.NewGuid().ToString(),
            BrandID = brands[0].BrandID,
            MainSupplierNr = suppliers[0].SupplierNr,
            PartGroupID = partGroups[0].PartGroupID,
            PartMakerCode = "PM1",
            PartName = "Engine Part 1",
            MainSupplierName = "Supplier A",
            PriceToUs = 50.00m,
            PriceToCustomer = 75.00m,
            OtherPartDetails = "High performance"
        },
        new Part
        {
            PartID = Guid.NewGuid().ToString(),
            BrandID = brands[1].BrandID,
            MainSupplierNr = suppliers[1].SupplierNr,
            PartGroupID = partGroups[1].PartGroupID,
            PartMakerCode = "PM2",
            PartName = "Brake Part 1",
            MainSupplierName = "Supplier B",
            PriceToUs = 20.00m,
            PriceToCustomer = 35.00m,
            OtherPartDetails = "Reliable braking"
        },
    };
            modelBuilder.Entity<Part>().HasData(parts);

            // Додавання даних для PartMaker
            var partMakers = new[]
            {
        new PartMaker { PartMakerCode = "PM1", PartMakerName = "Maker A" },
        new PartMaker { PartMakerCode = "PM2", PartMakerName = "Maker B" },
    };
            modelBuilder.Entity<PartMaker>().HasData(partMakers);

            // Додавання даних для Customer
            var customers = new[]
            {
        new Customer
        {
            CustomerID = Guid.NewGuid().ToString(),
            StatusCode = statuses[0].StatusCode,
            IndividualOrOrganisation = "Individual",
            OrganisationName = "",
            IndividualFirstName = "John",
            IndividualMiddleName = "A.",
            IndividualLastName = "Doe",
            OtherDetails = "Preferred customer"
        },
        new Customer
        {
            CustomerID = Guid.NewGuid().ToString(),
            StatusCode = statuses[1].StatusCode,
            IndividualOrOrganisation = "Organisation",
            OrganisationName = "Acme Corp",
            IndividualFirstName = "",
            IndividualMiddleName = "",
            IndividualLastName = "",
            OtherDetails = "Corporate account"
        },
    };
            modelBuilder.Entity<Customer>().HasData(customers);

            // Додавання даних для Order
            var orders = new[]
            {
        new Order
        {
            OrderID = Guid.NewGuid().ToString(),
            CustomerID = customers[0].CustomerID,
            OrderAmountDue = 200.00m,
            OtherDetails = "Urgent order"
        },
        new Order
        {
            OrderID = Guid.NewGuid().ToString(),
            CustomerID = customers[1].CustomerID,
            OrderAmountDue = 500.00m,
            OtherDetails = "Scheduled order"
        },
    };
            modelBuilder.Entity<Order>().HasData(orders);

        }


    }
}
