using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab6API.Migrations
{
    /// <inheritdoc />
    public partial class NewLogicForParts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Brands_BrandID",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartMakers_PartMakerCode",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Parts_PartGroupID",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_MainSupplierNr",
                table: "Parts");

            migrationBuilder.AlterColumn<string>(
                name: "MainSupplierName",
                table: "Parts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "PartID1",
                table: "Parts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PartGroups",
                columns: table => new
                {
                    PartGroupID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartGroupName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartGroups", x => x.PartGroupID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartID1",
                table: "Parts",
                column: "PartID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Brands_BrandID",
                table: "Parts",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartGroups_PartGroupID",
                table: "Parts",
                column: "PartGroupID",
                principalTable: "PartGroups",
                principalColumn: "PartGroupID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartMakers_PartMakerCode",
                table: "Parts",
                column: "PartMakerCode",
                principalTable: "PartMakers",
                principalColumn: "PartMakerCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Parts_PartID1",
                table: "Parts",
                column: "PartID1",
                principalTable: "Parts",
                principalColumn: "PartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_MainSupplierNr",
                table: "Parts",
                column: "MainSupplierNr",
                principalTable: "Suppliers",
                principalColumn: "SupplierNr",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Brands_BrandID",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartGroups_PartGroupID",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartMakers_PartMakerCode",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Parts_PartID1",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_MainSupplierNr",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "PartGroups");

            migrationBuilder.DropIndex(
                name: "IX_Parts_PartID1",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "PartID1",
                table: "Parts");

            migrationBuilder.AlterColumn<string>(
                name: "MainSupplierName",
                table: "Parts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Brands_BrandID",
                table: "Parts",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartMakers_PartMakerCode",
                table: "Parts",
                column: "PartMakerCode",
                principalTable: "PartMakers",
                principalColumn: "PartMakerCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Parts_PartGroupID",
                table: "Parts",
                column: "PartGroupID",
                principalTable: "Parts",
                principalColumn: "PartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_MainSupplierNr",
                table: "Parts",
                column: "MainSupplierNr",
                principalTable: "Suppliers",
                principalColumn: "SupplierNr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
