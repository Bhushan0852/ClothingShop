using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.API.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnonUserProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "UserProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OrderStatus",
                table: "UserProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OutForDelivery",
                table: "UserProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "OutForDelivery",
                table: "UserProducts");
        }
    }
}
