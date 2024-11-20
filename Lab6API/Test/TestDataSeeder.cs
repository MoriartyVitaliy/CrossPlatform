using Lab6API.Data;
using Lab6API.Model;
using System;
using System.Linq;

namespace Lab6API.Test
{
    public static class TestDataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Brands.Any()) return;

            var brands = new List<Brand>
            {
                new Brand { BrandID = 1, BrandName = "Brand1", BrandDetails = "Details about Brand1" },
                new Brand { BrandID = 2, BrandName = "Brand2", BrandDetails = "Details about Brand2" }
            };
            context.Brands.AddRange(brands);

            var carManufacturers = new List<CarManufacturer>
            {
                new CarManufacturer { CarManufacturerNr = 1, CarManufacturerName = "Manufacturer1" },
                new CarManufacturer { CarManufacturerNr = 2, CarManufacturerName = "Manufacturer2" }
            };
            context.CarManufacturers.AddRange(carManufacturers);

            var cars = new List<Car>
            {
                new Car { CarID = 1, CarManufacturerNr = 1, CarYearOfManufacture = 2020, CarModel = "Model1", OtherCarDetails = "Details for Model1" },
                new Car { CarID = 2, CarManufacturerNr = 2, CarYearOfManufacture = 2021, CarModel = "Model2", OtherCarDetails = "Details for Model2" }
            };
            context.Cars.AddRange(cars);


            var customerStatuses = new List<CustomerStatus>
            {
                new CustomerStatus { StatusCode = 1, StatusDescription = "Active" },
                new CustomerStatus { StatusCode = 2, StatusDescription = "Inactive" }
            };
            context.CustomerStatuses.AddRange(customerStatuses);

            var customers = new List<Customer>
            {
                new Customer
                {
                    CustomerID = 1, 
                    StatusCode = 1,
                    IndividualOrOrganisation = "Individual",
                    OrganisationName = "Aboba",
                    IndividualFirstName = "John",
                    IndividualMiddleName = "A",
                    IndividualLastName = "Doe",
                    OtherDetails = "Details for customer John"
                },
                new Customer
                {
                    CustomerID = 2,
                    StatusCode = 2, 
                    IndividualOrOrganisation = "Organisation",
                    OrganisationName = "Company1", 
                    IndividualFirstName = "Vitalii", 
                    IndividualMiddleName = "Shapoval",
                    IndividualLastName = "Vladimir",
                    OtherDetails = "Details for organisation customer"
                }
            };
            context.Customers.AddRange(customers);

            var orders = new List<Order>
            {
                new Order { OrderID = 1, CustomerID = 1, OrderAmountDue = 150.75M, OtherDetails = "Order 1 details" },
                new Order { OrderID = 2, CustomerID = 2, OrderAmountDue = 250.50M, OtherDetails = "Order 2 details" }
            };
            context.Orders.AddRange(orders);

            var suppliers = new List<Supplier>
            {
                new Supplier
                {
                    SupplierNr = 1, SupplierName = "Supplier1", StreetAddress = "123 Street", Town = "Town1",
                    County = "County1", Postcode = "12345", Phone = "123456", OtherDetails = "Details for Supplier1"
                },
                new Supplier
                {
                    SupplierNr = 2, SupplierName = "Supplier2", StreetAddress = "456 Avenue", Town = "Town2",
                    County = "County2", Postcode = "67890", Phone = "654321", OtherDetails = "Details for Supplier2"
                }
            };
            context.Suppliers.AddRange(suppliers);


            var partMakers = new List<PartMaker>
            {
                new PartMaker { PartMakerCode = 200, PartMakerName = "Success" },
                new PartMaker { PartMakerCode = 300, PartMakerName = "Hm..." }
            };
            context.PartMakers.AddRange(partMakers);

            var parts = new List<Part>
            {
                new Part
                {
                    PartID = 1, BrandID = 1, MainSupplierNr = 1, PartGroupID = 1, PartMakerCode = 200,
                    PartName = "Part1", MainSupplierName = "Supplier1", PriceToUs = 50.5M, PriceToCustomer = 75.75M,
                    OtherPartDetails = "Details for Part1"
                },
                new Part
                {
                    PartID = 2, BrandID = 2, MainSupplierNr = 2, PartGroupID = 1, PartMakerCode = 200,
                    PartName = "Part2", MainSupplierName = "Supplier2", PriceToUs = 60.0M, PriceToCustomer = 90.0M,
                    OtherPartDetails = "Details for Part2"
                }
            };
            context.Parts.AddRange(parts);

            var partSuppliers = new List<PartSupplier>
            {
                new PartSupplier { PartSupplierID = 1, PartID = 1, SupplierID = 1 },
                new PartSupplier { PartSupplierID = 2, PartID = 2, SupplierID = 2 }
            };
            context.PartSuppliers.AddRange(partSuppliers);

            var partsForCars = new List<PartForCar>
            {
                new PartForCar { PartID = 1, CarID = 1 },
                new PartForCar { PartID = 2, CarID = 2 }
            };
            context.PartsForCars.AddRange(partsForCars);

            var partsInOrders = new List<PartInOrder>
            {
                new PartInOrder { PartInOrderID = 1, OrderID = 1, PartSupplierID = 1, ActualSalesPrice = 80.0M, Quantity = 2 },
                new PartInOrder { PartInOrderID = 2, OrderID = 2, PartSupplierID = 2, ActualSalesPrice = 100.0M, Quantity = 3 }
            };
            context.PartsInOrders.AddRange(partsInOrders);

            context.SaveChanges();


        }
    }
}
