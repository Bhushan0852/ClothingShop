using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.API.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnproducttableskuincrementvalandvcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VendorCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendorCode",
                table: "Products");
        }
    }
}
