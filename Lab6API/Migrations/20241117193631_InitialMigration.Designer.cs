﻿// <auto-generated />
using Lab6API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab6API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241117193631_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Lab6API.Model.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BrandDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Lab6API.Model.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarManufacturerNr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CarYearOfManufacture")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OtherCarDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CarID");

                    b.HasIndex("CarManufacturerNr");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Lab6API.Model.CarManufacturer", b =>
                {
                    b.Property<int>("CarManufacturerNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarManufacturerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CarManufacturerNr");

                    b.ToTable("CarManufacturers");
                });

            modelBuilder.Entity("Lab6API.Model.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("IndividualFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IndividualLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IndividualMiddleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IndividualOrOrganisation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerID");

                    b.HasIndex("StatusCode");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Lab6API.Model.CustomerStatus", b =>
                {
                    b.Property<int>("StatusCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StatusCode");

                    b.ToTable("CustomerStatuses");
                });

            modelBuilder.Entity("Lab6API.Model.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("OrderAmountDue")
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Lab6API.Model.Part", b =>
                {
                    b.Property<int>("PartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MainSupplierName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MainSupplierNr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OtherPartDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PartGroupID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PartMakerCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PriceToCustomer")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PriceToUs")
                        .HasColumnType("TEXT");

                    b.HasKey("PartID");

                    b.HasIndex("BrandID");

                    b.HasIndex("MainSupplierNr");

                    b.HasIndex("PartGroupID");

                    b.HasIndex("PartMakerCode");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("Lab6API.Model.PartForCar", b =>
                {
                    b.Property<int>("PartID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PartID", "CarID");

                    b.HasIndex("CarID");

                    b.ToTable("PartsForCars");
                });

            modelBuilder.Entity("Lab6API.Model.PartInOrder", b =>
                {
                    b.Property<int>("PartInOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ActualSalesPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PartSupplierID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("PartInOrderID");

                    b.HasIndex("OrderID");

                    b.HasIndex("PartSupplierID");

                    b.ToTable("PartsInOrders");
                });

            modelBuilder.Entity("Lab6API.Model.PartMaker", b =>
                {
                    b.Property<string>("PartMakerCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("PartMakerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PartMakerCode");

                    b.ToTable("PartMakers");
                });

            modelBuilder.Entity("Lab6API.Model.PartSupplier", b =>
                {
                    b.Property<int>("PartSupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PartID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SupplierID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PartSupplierID");

                    b.HasIndex("PartID");

                    b.HasIndex("SupplierID");

                    b.ToTable("PartSuppliers");
                });

            modelBuilder.Entity("Lab6API.Model.Supplier", b =>
                {
                    b.Property<int>("SupplierNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SupplierNr");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Lab6API.Model.Car", b =>
                {
                    b.HasOne("Lab6API.Model.CarManufacturer", "CarManufacturer")
                        .WithMany("Cars")
                        .HasForeignKey("CarManufacturerNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarManufacturer");
                });

            modelBuilder.Entity("Lab6API.Model.Customer", b =>
                {
                    b.HasOne("Lab6API.Model.CustomerStatus", "CustomerStatus")
                        .WithMany("Customers")
                        .HasForeignKey("StatusCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerStatus");
                });

            modelBuilder.Entity("Lab6API.Model.Order", b =>
                {
                    b.HasOne("Lab6API.Model.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Lab6API.Model.Part", b =>
                {
                    b.HasOne("Lab6API.Model.Brand", "Brand")
                        .WithMany("Parts")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6API.Model.Supplier", "Supplier")
                        .WithMany("SupplierID")
                        .HasForeignKey("MainSupplierNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6API.Model.Part", "PartGroup")
                        .WithMany("SubParts")
                        .HasForeignKey("PartGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6API.Model.PartMaker", "PartMaker")
                        .WithMany("Parts")
                        .HasForeignKey("PartMakerCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("PartGroup");

                    b.Navigation("PartMaker");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Lab6API.Model.PartForCar", b =>
                {
                    b.HasOne("Lab6API.Model.Car", "Car")
                        .WithMany("PartsForCars")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6API.Model.Part", "Part")
                        .WithMany("PartsForCars")
                        .HasForeignKey("PartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Lab6API.Model.PartInOrder", b =>
                {
                    b.HasOne("Lab6API.Model.Order", "Order")
                        .WithMany("PartsInOrders")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6API.Model.PartSupplier", "PartSupplier")
                        .WithMany("PartInOrders")
                        .HasForeignKey("PartSupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("PartSupplier");
                });

            modelBuilder.Entity("Lab6API.Model.PartSupplier", b =>
                {
                    b.HasOne("Lab6API.Model.Part", "Part")
                        .WithMany("PartSuppliers")
                        .HasForeignKey("PartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6API.Model.Supplier", "Supplier")
                        .WithMany("PartSuppliers")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Lab6API.Model.Brand", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("Lab6API.Model.Car", b =>
                {
                    b.Navigation("PartsForCars");
                });

            modelBuilder.Entity("Lab6API.Model.CarManufacturer", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Lab6API.Model.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Lab6API.Model.CustomerStatus", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Lab6API.Model.Order", b =>
                {
                    b.Navigation("PartsInOrders");
                });

            modelBuilder.Entity("Lab6API.Model.Part", b =>
                {
                    b.Navigation("PartSuppliers");

                    b.Navigation("PartsForCars");

                    b.Navigation("SubParts");
                });

            modelBuilder.Entity("Lab6API.Model.PartMaker", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("Lab6API.Model.PartSupplier", b =>
                {
                    b.Navigation("PartInOrders");
                });

            modelBuilder.Entity("Lab6API.Model.Supplier", b =>
                {
                    b.Navigation("PartSuppliers");

                    b.Navigation("SupplierID");
                });
#pragma warning restore 612, 618
        }
    }
}
