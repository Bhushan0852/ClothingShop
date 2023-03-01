using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.API.Migrations
{
    /// <inheritdoc />
    public partial class addvaluecolumnproducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "SKUIncrementVal",
            //    table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "IncValue",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "IncValue",
            //    table: "Products");

            //migrationBuilder.AddColumn<int>(
            //    name: "SKUIncrementVal",
            //    table: "Products",
            //    type: "int",
            //    nullable: true);
        }
    }
}
