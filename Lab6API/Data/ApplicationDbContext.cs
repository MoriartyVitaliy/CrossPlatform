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
        }


    }
}
