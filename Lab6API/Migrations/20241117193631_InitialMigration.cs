using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab6API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrandName = table.Column<string>(type: "TEXT", nullable: false),
                    BrandDetails = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "CarManufacturers",
                columns: table => new
                {
                    CarManufacturerNr = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarManufacturerName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarManufacturers", x => x.CarManufacturerNr);
                });

            migrationBuilder.CreateTable(
                name: "CustomerStatuses",
                columns: table => new
                {
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatusDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerStatuses", x => x.StatusCode);
                });

            migrationBuilder.CreateTable(
                name: "PartMakers",
                columns: table => new
                {
                    PartMakerCode = table.Column<string>(type: "TEXT", nullable: false),
                    PartMakerName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartMakers", x => x.PartMakerCode);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierNr = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SupplierName = table.Column<string>(type: "TEXT", nullable: false),
                    StreetAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Town = table.Column<string>(type: "TEXT", nullable: false),
                    County = table.Column<string>(type: "TEXT", nullable: false),
                    Postcode = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    OtherDetails = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierNr);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarManufacturerNr = table.Column<int>(type: "INTEGER", nullable: false),
                    CarYearOfManufacture = table.Column<int>(type: "INTEGER", nullable: false),
                    CarModel = table.Column<string>(type: "TEXT", nullable: false),
                    OtherCarDetails = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Cars_CarManufacturers_CarManufacturerNr",
                        column: x => x.CarManufacturerNr,
                        principalTable: "CarManufacturers",
                        principalColumn: "CarManufacturerNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false),
                    IndividualOrOrganisation = table.Column<string>(type: "TEXT", nullable: false),
                    OrganisationName = table.Column<string>(type: "TEXT", nullable: false),
                    IndividualFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    IndividualMiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    IndividualLastName = table.Column<string>(type: "TEXT", nullable: false),
                    OtherDetails = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerStatuses_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "CustomerStatuses",
                        principalColumn: "StatusCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrandID = table.Column<int>(type: "INTEGER", nullable: false),
                    MainSupplierNr = table.Column<int>(type: "INTEGER", nullable: false),
                    PartGroupID = table.Column<int>(type: "INTEGER", nullable: false),
                    PartMakerCode = table.Column<string>(type: "TEXT", nullable: false),
                    PartName = table.Column<string>(type: "TEXT", nullable: false),
                    MainSupplierName = table.Column<string>(type: "TEXT", nullable: false),
                    PriceToUs = table.Column<decimal>(type: "TEXT", nullable: false),
                    PriceToCustomer = table.Column<decimal>(type: "TEXT", nullable: false),
                    OtherPartDetails = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartID);
                    table.ForeignKey(
                        name: "FK_Parts_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parts_PartMakers_PartMakerCode",
                        column: x => x.PartMakerCode,
                        principalTable: "PartMakers",
                        principalColumn: "PartMakerCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parts_Parts_PartGroupID",
                        column: x => x.PartGroupID,
                        principalTable: "Parts",
                        principalColumn: "PartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parts_Suppliers_MainSupplierNr",
                        column: x => x.MainSupplierNr,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderAmountDue = table.Column<decimal>(type: "TEXT", nullable: false),
                    OtherDetails = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartsForCars",
                columns: table => new
                {
                    PartID = table.Column<int>(type: "INTEGER", nullable: false),
                    CarID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsForCars", x => new { x.PartID, x.CarID });
                    table.ForeignKey(
                        name: "FK_PartsForCars_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartsForCars_Parts_PartID",
                        column: x => x.PartID,
                        principalTable: "Parts",
                        principalColumn: "PartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartSuppliers",
                columns: table => new
                {
                    PartSupplierID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartID = table.Column<int>(type: "INTEGER", nullable: false),
                    SupplierID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartSuppliers", x => x.PartSupplierID);
                    table.ForeignKey(
                        name: "FK_PartSuppliers_Parts_PartID",
                        column: x => x.PartID,
                        principalTable: "Parts",
                        principalColumn: "PartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartSuppliers_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartsInOrders",
                columns: table => new
                {
                    PartInOrderID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false),
                    PartSupplierID = table.Column<int>(type: "INTEGER", nullable: false),
                    ActualSalesPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsInOrders", x => x.PartInOrderID);
                    table.ForeignKey(
                        name: "FK_PartsInOrders_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartsInOrders_PartSuppliers_PartSupplierID",
                        column: x => x.PartSupplierID,
                        principalTable: "PartSuppliers",
                        principalColumn: "PartSupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarManufacturerNr",
                table: "Cars",
                column: "CarManufacturerNr");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StatusCode",
                table: "Customers",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_BrandID",
                table: "Parts",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_MainSupplierNr",
                table: "Parts",
                column: "MainSupplierNr");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartGroupID",
                table: "Parts",
                column: "PartGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartMakerCode",
                table: "Parts",
                column: "PartMakerCode");

            migrationBuilder.CreateIndex(
                name: "IX_PartsForCars_CarID",
                table: "PartsForCars",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_PartsInOrders_OrderID",
                table: "PartsInOrders",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_PartsInOrders_PartSupplierID",
                table: "PartsInOrders",
                column: "PartSupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_PartSuppliers_PartID",
                table: "PartSuppliers",
                column: "PartID");

            migrationBuilder.CreateIndex(
                name: "IX_PartSuppliers_SupplierID",
                table: "PartSuppliers",
                column: "SupplierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartsForCars");

            migrationBuilder.DropTable(
                name: "PartsInOrders");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PartSuppliers");

            migrationBuilder.DropTable(
                name: "CarManufacturers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "CustomerStatuses");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "PartMakers");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
